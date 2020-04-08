// GNU License Copyright (c) 2020 Javier Cañon | https://www.javiercanon.com
using System.ComponentModel;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace SharkErrorReporter.DAL.SystemInfo
{
    public enum QueryArea
    {
        [Description("Win32_ComputerSystem")] WMI_COMPUTER_INFORMATION,
        [Description("Win32_Processor")] WMI_PROCESSOR_INFORMATION,
        [Description("Win32_BIOS")] WMI_BIOS_INFORMATION,
        [Description("Win32_OperatingSystem")] WMI_OS_INFORMATION,
        [Description("Win32_QuickFixEngineering")] WMI_HOTFIX_INFORMATION,
        [Description("Win32_NetworkAdapterConfiguration")] WMI_NETWORK_ADAPTER_INFORMATION,
        [Description("Win32_Printer")] WMI_PRINTER_INFORMATION,
        [Description("Win32_DiskDrive")] WMI_DISK_DRIVE_INFORMATION,
        [Description("Win32_LogicalDisk")] WMI_LOGICAL_DISK_INFORMATION,
        [Description("Win32_VideoController")] WMI_VIDEO_CONTROLLER_INFORMATION,
        [Description("Win32_SoundDevice")] WMI_SOUND_CARD_INFORMATION
    }
}