// MIT License
// Copyright (c) Javier Cañon, Peter van der Woude 
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
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
