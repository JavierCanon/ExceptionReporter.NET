using System.Collections.Generic;
using System.Linq;
using ExceptionReporting.Core;

namespace ExceptionReporting.Mail
{
	internal class Attacher
	{
		private const string ZIP = ".zip";
		public IFileService File { private get; set; } = new FileService();
		public IZipper Zipper { private get; set; } = new Zipper();
		public IScreenshotTaker ScreenshotTaker { private get; set; } = new ScreenshotTaker();
		public ExceptionReportInfo Config { get; }

		public Attacher(ExceptionReportInfo config)
		{
			Config = config;
		}

		public void AttachFiles(IAttach attacher)
		{
			var files = new List<string>();
			if (Config.FilesToAttach.Length > 0)
			{
				files.AddRange(Config.FilesToAttach);
			}

			try
			{
				if (Config.TakeScreenshot && !Config.ScreenshotAvailable)
					Config.ScreenshotImage = ScreenshotTaker.TakeScreenShot();
			}
			catch { /* ignored */ }

			if (Config.ScreenshotAvailable)
			{
				files.Add(ScreenshotTaker.GetImageAsFile(Config.ScreenshotImage));
			}

			var filesThatExist = files.Where(f => File.Exists(f)).ToList();

			// attach external zip files separately - admittedly weak detection using just file extension
			filesThatExist.Where(f => f.EndsWith(ZIP)).ToList().ForEach(attacher.Attach);

			// now zip & attach all specified files (ie config FilesToAttach) plus screenshot, if taken
			var filesToZip = filesThatExist.Where(f => !f.EndsWith(ZIP)).ToList();
			if (filesToZip.Any())
			{
				var zipFile = File.TempFile(Config.AttachmentFilename);
				Zipper.Zip(zipFile, filesToZip);
				attacher.Attach(zipFile);
			}
		}
	}
}
