// GNU License Copyright (c) 2020 Javier Cañon | https://www.javiercanon.com
namespace SharkErrorReporter.SystemInfo
{
	/// <summary>
	/// describes a query to SysInfo (more precisely, the Windows 'WMI' ManagementObjectSearcher)
	/// </summary>
	internal class SysInfoQuery
	{
		private readonly bool _useNameAsDisplayField;

		public SysInfoQuery(string name, string query, bool useNameAsDisplayField)
		{
			Name = name;
			_useNameAsDisplayField = useNameAsDisplayField;
			QueryText = query;
		}

		public string QueryText { get; }

		public string DisplayField
		{
			get { return _useNameAsDisplayField ? "Name" : "Caption"; }
		}

		public string Name { get; }
	}
}
