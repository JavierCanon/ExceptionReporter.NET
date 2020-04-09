using System;
using System.Collections.Generic;

namespace bigtalljosh.ErrorReport
{
    public class SendGridEmail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, string> Substitutions { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string TemplateId { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
