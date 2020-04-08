// MIT License
// Copyright (c) 2009 Javier Cañon https://www.javiercanon.com
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
using System;
using System.Threading;
using System.Windows.Forms;
using SharkErrorReporter;

namespace Demo.WinForms {
  public static class Program {
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	public static void Main() {

	  Application.ThreadException += new ExceptionHandler().ApplicationThreadException;
	  AppDomain.CurrentDomain.UnhandledException += new ExceptionHandler().DomainUnhandledException;

	  Application.EnableVisualStyles();
	  Application.SetCompatibleTextRenderingDefault(false);
	  Application.Run(new DemoAppView());
	}

	class ExceptionHandler {
	  public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e) {
			ExceptionReporter reporter = new ExceptionReporter();
			reporter.Show(e.Exception);
	  }

	  public void DomainUnhandledException(object sender, UnhandledExceptionEventArgs e) {
			ExceptionReporter reporter = new ExceptionReporter();
			reporter.Show((Exception)e.ExceptionObject);
			// reporter.Send((Exception)e.ExceptionObject);  // send these silently (ie without showing dialog)
	  }
	}



  }
}