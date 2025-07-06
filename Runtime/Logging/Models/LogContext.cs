using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace skner.Logging.Models
{
    /// <summary>
    /// The LogContext struct represents the contextual information for a log message.
    /// </summary>
    [Serializable]
    public struct LogContext
    {
        /// <summary>
        /// Timestamp when the log message was created.
        /// </summary>
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The log level information associated with the log message.
        /// </summary>
        public LogLevelDetail LogLevel { get; internal set; }

        /// <summary>
        /// The Source label for the logger which the log message was generated.
        /// </summary>
        public string SourceLogger { get; internal set; }

        /// <summary>
        /// The line number in the source code where the log message was generated.
        /// </summary>
        public int LineNumber { get; internal set; }

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
        /// List of <see cref="StackFrame"/>s from the Log <see cref="StackTrace"/>.
        /// </summary>
        public List<StackFrame> StackFrames { get; internal set; }

    }
}