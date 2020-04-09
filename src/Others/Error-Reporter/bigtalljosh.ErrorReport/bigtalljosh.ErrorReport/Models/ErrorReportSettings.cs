namespace bigtalljosh.ErrorReport
{
    public class ErrorReportSettings
    {
        // Database Settings
        public string DbConnectionString { get; set; }

        // Logging Settings
        public bool LogToLocalFile { get; set; }
        public string LocalLogFilePath { get; set; }
        public bool LogToMsSql { get; set; }

        // Email settings
        public string SendGridAPIKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string ErrorLogRecipientEmail { get; set; }
        public string ErrorLogRecipientName { get; set; }
        public string ErrorEmailTemplateId { get; set; }
    }
}
