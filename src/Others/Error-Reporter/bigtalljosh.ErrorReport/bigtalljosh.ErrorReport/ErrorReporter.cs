using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Microsoft.ApplicationInsights;

namespace bigtalljosh.ErrorReport
{
    public class ErrorReporter
    {
        private readonly ILogger _logger;
        private readonly TelemetryClient _telemetry;
        private readonly SendGridProvider _sendGrid;
        private readonly ErrorReportSettings _settings;

        public ErrorReporter(ErrorReportSettings settings, TelemetryClient telemetry = null)
        {
            _settings = settings;

            if (telemetry != null)
                _telemetry = telemetry;

            if (!string.IsNullOrEmpty(_settings.SendGridAPIKey))
                _sendGrid = new SendGridProvider(_settings);

            /*
            Level	    | Usage
            ------------|---------------
            Verbose	    | Verbose is the noisiest level, rarely (if ever) enabled for a production app.
            Debug	    | Debug is used for internal system events that are not necessarily observable from the outside, but useful when determining how something happened.
            Information | Information events describe things happening in the system that correspond to its responsibilities and functions. Generally these are the observable actions the system can perform.
            Warning     | When service is degraded, endangered, or may be behaving outside of its expected parameters, Warning level events are used.
            Error       | When functionality is unavailable or expectations broken, an Error event is used.
            Fatal       | The most critical level, Fatal events demand immediate attention.
            */

            if (_settings.LogToLocalFile && !_settings.LogToMsSql)
            {
                _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"{_settings.LocalLogFilePath}\\{DateTime.Now.Date} - Error-Logs.txt", Serilog.Events.LogEventLevel.Debug)
                .CreateLogger();
            }
            else if (_settings.LogToMsSql && !_settings.LogToLocalFile)
            {
                _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.MSSqlServer(_settings.DbConnectionString, "Logs", Serilog.Events.LogEventLevel.Debug)
                .CreateLogger();
            }
            else if (_settings.LogToMsSql && _settings.LogToLocalFile)
            {
                _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"{_settings.LocalLogFilePath}\\{DateTime.Now.Date} - Error-Logs.txt", Serilog.Events.LogEventLevel.Debug)
                .WriteTo.MSSqlServer(_settings.DbConnectionString, "Logs", Serilog.Events.LogEventLevel.Debug)
                .CreateLogger();
            }
            else
            {
                _logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File($"{System.IO.Directory.GetCurrentDirectory()}\\{DateTime.Now.Date.ToShortDateString()} - Error-Logs.txt")
                    .CreateLogger();
            }
        }

        /// <summary>
        /// Logs an exception with the data model
        /// </summary>
        /// <param name="callingMethod">The name of the method that caused the issue</param>
        /// <param name="ex">The exception object with stack trace</param>
        /// <param name="notify">Optional ability to send a notification</param>
        /// <param name="model">The serialised data object in json or xml</param>
        /// <param name="customMessage">Optionally override the default exception message</param>
        /// <returns></returns>
        public async Task LogExceptionAsync(string callingMethod, Exception ex, bool notify = false, string model = null, string customMessage = null)
        {
            var errorMessage = string.IsNullOrEmpty(customMessage) ? ex.Message : customMessage;

            _logger.Error(ex, $"There was an error during the {callingMethod} Method. The exception thrown is: {errorMessage}. The Stack Trace is: {ex.StackTrace}. The InnerException is: {ex.InnerException}", model);

            if (_telemetry != null)
                _telemetry.TrackException(ex);

            var log = new Log
            {
                Type = LogType.Error,
                Message = errorMessage,
                StackTrace = ex.StackTrace ?? "No Stack",
                DateCreated = DateTime.Now,
                CallingMethod = callingMethod,
                SerialisedObject = model ?? "Not Available"
            };

            if (notify)
            {
                if (_sendGrid != null)
                {
                    var email = Create(log);
                    await _sendGrid.SendAsync(email);
                }
            }
        }

        private SendGridEmail Create(Log log)
        {
            var substitutions = new Dictionary<string, string>
            {
                { "-ERROR-", log.Message },
                { "-ERRORDATE-", DateTime.Now.ToString() },
                { "-APPLICATION-", log.CallingMethod },
                { "-ORIGINALOBJECT-", log.SerialisedObject }
            };

            return new SendGridEmail
            {
                To = $"{_settings.ErrorLogRecipientEmail}",
                Subject = $"Error Log: { log.Message }",
                Body = log.StackTrace,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                TemplateId = $"{_settings.ErrorEmailTemplateId}",
                Substitutions = substitutions
            };
        }
    }
}
