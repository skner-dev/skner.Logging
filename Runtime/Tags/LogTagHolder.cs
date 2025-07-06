using System;

namespace skner.Logging.Tags
{
    /// <summary>
    /// A struct that holds Tags and their values when instantiated.
    /// </summary>
    [Serializable]
    public struct LogTagHolder
    {
        /// <summary>
        /// The timestamp when the log message was created.
        /// </summary>
        public string Timestamp { get; internal set; }

        /// <summary>
        /// The name of the log level associated with the log message.
        /// </summary>
        public string LogLevelName { get; internal set; }

        /// <summary>
        /// The hexadecimal color code associated with the log level.
        /// </summary>
        public string LogLevelHexColor { get; internal set; }

        /// <summary>
        /// The source label for the logger from which the log message was generated.
        /// </summary>
        public string SourceLogger { get; internal set; }

        /// <summary>
        /// The line number in the source code where the log message was generated.
        /// </summary>
        public int? LineNumber { get; internal set; }

        /// <summary>
        /// The full class name from which the log message originated.
        /// </summary>
        public string ClassName { get; internal set; }

        /// <summary>
        /// The method name from which the log message originated.
        /// </summary>
        public string MethodName { get; internal set; }

        /// <summary>
        /// The log message.
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// The stack trace associated with the log message in string format.
        /// </summary>
        public string StackTrace { get; internal set; }
    }
}