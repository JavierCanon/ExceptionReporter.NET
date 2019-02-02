// MIT License
// Copyright (c) Javier Ca�on, Peter van der Woude 
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
using System;
using System.Collections.Generic;
using SharkErrorReporter.Mail;

#pragma warning disable 1591

namespace SharkErrorReporter.Views
{
	/// <summary>
	/// The interface (contract) for an ExceptionReportView
	/// </summary>
	public interface IExceptionReportView : IReportSendEvent
	{
		string ProgressMessage { set; }
		bool EnableEmailButton { set; }
		bool ShowProgressBar { set; }
		bool ShowFullDetail { get; set; }
		string UserExplanation { get; }
		void SetEmailCompletedState_WithMessageIfSuccess(bool success, string successMessage);
		void SetInProgressState();
		void PopulateExceptionTab(IList<Exception> exceptions);
		void PopulateAssembliesTab();
		void PopulateSysInfoTab();
		void SetProgressCompleteState();
		void ToggleShowFullDetail();
		void ShowExceptionReport();
	}
}

#pragma warning restore 1591
