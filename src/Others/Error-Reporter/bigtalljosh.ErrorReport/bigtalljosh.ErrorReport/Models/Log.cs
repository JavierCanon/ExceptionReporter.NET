using System;

namespace bigtalljosh.ErrorReport
{
    public class Log
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public string CallingMethod { get; set; }
        public string SerialisedObject { get; set; }
    }

    public enum LogType
    {
        Error,
        Trace,
        Debug,
        Custom
    }
}