using System;

namespace skner.Logging.Models
{
    /// <summary>
    /// The LogFormat struct represents a custom log format string used for formatting log messages.
    /// </summary>
    /// <remarks>
    /// It supports <see cref="LogContext"/> tags and Rich Text tags.
    /// </remarks>
    [Serializable]
    public struct LogFormat
    {
        /// <summary>
        /// The format string that defines how log messages are formatted.
        /// </summary>
        public string Format;

        internal LogFormat(string format)
        {
            Format = format;
        }
    }

}