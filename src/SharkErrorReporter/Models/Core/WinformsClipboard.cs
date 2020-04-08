// GNU License Copyright (c) 2020 Javier Cañon | https://www.javiercanon.com
using System;

namespace SharkErrorReporter.Core
{
	internal class WinFormsClipboard
	{
		public static void CopyTo(string text)
		{
			System.Windows.Forms.Clipboard.SetDataObject(text, true);
		}
	}
}