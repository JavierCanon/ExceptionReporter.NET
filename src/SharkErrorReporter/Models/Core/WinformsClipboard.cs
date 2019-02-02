// MIT License
// Copyright (c) Javier Cañon, Peter van der Woude 
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
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