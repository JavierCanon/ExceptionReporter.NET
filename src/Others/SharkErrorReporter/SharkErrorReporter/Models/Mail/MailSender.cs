// GNU License Copyright (c) 2020 Javier Ca�on | https://www.javiercanon.com
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using SharkErrorReporter.Core;
//using Win32Mapi;

namespace SharkErrorReporter.Mail
{
	internal class MailSender
	{
		private readonly ExceptionReportInfo _config;
		private readonly IReportSendEvent _reportEvent;
		private readonly Attacher _attacher;

		internal MailSender(ExceptionReportInfo reportInfo, IReportSendEvent reportEvent)
		{
			_config = reportInfo;
			_reportEvent = reportEvent;
			_attacher = new Attacher(reportInfo);
		}

		/// <summary>
		/// Send SMTP email, uses native .NET SmtpClient library
		/// Requires following ExceptionReportInfo properties to be set:
		/// SmtpPort, SmtpUseSsl, SmtpUsername, SmtpPassword, SmtpFromAddress, EmailReportAddress
		/// </summary>
		public void SendSmtp(string exceptionReport)
		{
			var smtp = new SmtpClient(_config.SmtpServer)
			{
				DeliveryMethod = SmtpDeliveryMethod.Network,
				EnableSsl = _config.SmtpUseSsl,
				UseDefaultCredentials = _config.SmtpUseDefaultCredentials,
			};

			if (_config.SmtpPort != 0)		// the default port (25) is used if not set in config
				smtp.Port = _config.SmtpPort;
			if (_config.SmtpUseDefaultCredentials == false)
				smtp.Credentials = new NetworkCredential(_config.SmtpUsername, _config.SmtpPassword);

			var message = new MailMessage(_config.SmtpFromAddress, _config.EmailReportAddress)
			{
				BodyEncoding = Encoding.UTF8,
				SubjectEncoding = Encoding.UTF8,
				Body = exceptionReport,
				Subject = EmailSubject
			};

			_attacher.AttachFiles(new AttachAdapter(message));

			smtp.SendCompleted += (sender, e) =>
			{
				try
				{
					if (e.Error == null)
					{
						_reportEvent.Completed(success: true);
					}
					else
					{
						_reportEvent.Completed(success: false);
						_reportEvent.ShowError(e.Error.Message, e.Error);
					}
				}
				finally 
				{
					message.Dispose();
					smtp.Dispose();
				}
			};

			smtp.SendAsync(message, "Exception Report");
		}

		/// <summary>
		/// Send email via installed client - uses Simple-MAPI.NET library - https://github.com/PandaWood/Simple-MAPI.NET
		/// </summary>
		public void SendMapi(string exceptionReport)
		{
	  //TODO: uptate to native, really need mapi?...
		/*
	  var mapi = new SimpleMapi();

			mapi.AddRecipient(_config.EmailReportAddress, null, false);
			_attacher.AttachFiles(new AttachAdapter(mapi));

			mapi.Send(EmailSubject, exceptionReport);*/

		}

		public string EmailSubject
		{
			get { return _config.MainException?.Message.Replace('\r', ' ').Replace('\n', ' ').Truncate(100) ?? "Exception Report"; }
		}
	}
}