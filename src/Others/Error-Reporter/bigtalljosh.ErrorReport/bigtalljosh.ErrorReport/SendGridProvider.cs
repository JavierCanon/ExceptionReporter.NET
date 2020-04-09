using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace bigtalljosh.ErrorReport
{
    public class SendGridProvider
    {
        private static string _apiKey;
        private readonly ErrorReportSettings _settings;

        public SendGridProvider(ErrorReportSettings settings)
        {
            _settings = settings;
            _apiKey = _settings.SendGridAPIKey;
        }

        /// <summary>
        /// Send the message whilst checking if we should ignore this message
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task SendAsync(SendGridEmail email)
        {
            if (!Ignore(email))
            {
                var msg = BuildMessage(email);
                await SendAsync(msg);
            }
        }

        /// <summary>
        /// Send the message 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async Task<Response> SendAsync(SendGridMessage message)
        {
            var client = new SendGridClient(_apiKey);
            return await client.SendEmailAsync(message);
        }

        /// <summary>
        /// Build the sendgrid message from my model
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        private SendGridMessage BuildMessage(SendGridEmail notification)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress(_settings.SenderEmail, _settings.SenderName));
            msg.SetSubject(notification.Subject);
            msg.AddTo(new EmailAddress(_settings.ErrorLogRecipientEmail, _settings.ErrorLogRecipientName));
            msg.AddContent(MimeType.Html, notification.Body);
            msg.SetTemplateId(_settings.ErrorEmailTemplateId);

            AddSubstitutions(msg, notification.Substitutions);

            return msg;
        }

        /// <summary>
        /// Add any substitutions we have to the message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="subs"></param>
        private static void AddSubstitutions(SendGridMessage message, Dictionary<string, string> subs)
        {
            foreach (var pair in subs)
                message.AddSubstitution(pair.Key, pair.Value);
        }

        /// <summary>
        /// We can ignore certain errors we never want to receive an email for
        /// </summary>
        /// <param name="model">The email object</param>
        /// <returns></returns>
        private bool Ignore(SendGridEmail model)
        {
            // an array of emails to ignore
            string[] ignores = new string[]{"",""};

            // loop through each element and check if we should ignore it
            foreach (var value in model.Substitutions.Values)
                if (ignores.Contains(value))
                    return true;
            
            return false;
        }
    }
}
