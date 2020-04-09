// GNU License Copyright (c) 2020 Javier Cañon | https://www.javiercanon.com
using System;

namespace SharkErrorReporter
{
	/// <summary>
	/// Email send event.
	/// </summary>
	public interface IReportSendEvent
	{
		/// <summary>
		/// send completed
		/// </summary>
		void Completed(bool success);

		/// <summary>
		/// show an error
		/// </summary>
		void ShowError(string message, Exception exception);
	}
}
