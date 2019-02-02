// MIT License
// Copyright (c) Javier Cañon, Peter van der Woude 
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
namespace SharkErrorReporter.SystemInfo
{
	internal class SysInfoQueries
	{
		public static readonly SysInfoQuery OperatingSystem = new SysInfoQuery("Operating System", "Win32_OperatingSystem", false);
		public static readonly SysInfoQuery Machine = new SysInfoQuery("Machine", "Win32_ComputerSystem", true);
	}
}