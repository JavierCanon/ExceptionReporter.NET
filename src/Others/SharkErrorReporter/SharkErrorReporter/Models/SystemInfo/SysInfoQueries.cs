// GNU License Copyright (c) 2020 Javier Cañon | https://www.javiercanon.com
namespace SharkErrorReporter.SystemInfo
{
	internal class SysInfoQueries
	{
		public static readonly SysInfoQuery OperatingSystem = new SysInfoQuery("Operating System", "Win32_OperatingSystem", false);
		public static readonly SysInfoQuery Machine = new SysInfoQuery("Machine", "Win32_ComputerSystem", true);
	}
}