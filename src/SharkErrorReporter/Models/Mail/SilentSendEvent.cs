// MIT License
// Copyright (c) Javier Cañon, Peter van der Woude 
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
using System;

namespace SharkErrorReporter.Mail
{
	/// <summary>
	/// A fake/slient version of the events responding to sending
	/// </summary>
	public class SilentSendEvent : IReportSendEvent
	{
		/// <summary>
		/// silent complete
		/// </summary>
		public void Completed(bool success)
		{
			// silent
		}

		/// <summary>
		/// silent error
		/// </summary>
		public void ShowError(string message, Exception exception)
		{
			// silent
		}
	}
}