﻿using ExceptionReporting.Core;
using ExceptionReporting.Mail;
using ExceptionReporting.Network.Events;

namespace ExceptionReporting.Network.Senders
{
	internal abstract class MailSender
	{
		protected readonly ExceptionReportInfo _config;
		protected readonly IReportSendEvent _sendEvent;
		protected readonly Attacher _attacher;

		protected MailSender(ExceptionReportInfo reportInfo, IReportSendEvent sendEvent)
		{
			_config = reportInfo;
			_sendEvent = sendEvent;
			_attacher = new Attacher(reportInfo);
		}

		public abstract string Description { get; }

		public virtual string ConnectingMessage
		{
			get { return string.Format("Connecting {0}...", Description); }
		}

		public string EmailSubject
		{
			get { return _config.MainException?.Message
				             .Replace('\r', ' ')
				             .Replace('\n', ' ')
				             .Truncate(255) ?? "Exception Report"; }
		}
	}
}