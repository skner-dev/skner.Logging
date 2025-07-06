using skner.Logging.Abstracts;
using skner.Logging.Models;
using skner.Logging.Settings;
using System.Diagnostics;

namespace skner.Logging.Loggers
{
    /// <summary>
    /// The ClassLogger is a logger used within classes to log messages. It inherits from the BaseLogger class
    /// and is typically created with specific LoggerSettings to control its behavior.
    /// </summary>
    public class ClassLogger : BaseLogger
    {

        private readonly string _loggerLabel;
        private protected override string LoggerLabel => _loggerLabel;

        /// <summary>
        /// Initializes a new instance of the ClassLogger class with the specified LoggerSettings.
        /// </summary>
        /// <param name="settings">The LoggerSettings to configure the logger's behavior.</param>
        public ClassLogger(LoggerSettings settings) : base(settings)
        {
            _loggerLabel = DetermineLoggerLabel();
        }

        /// <summary>
        /// Initializes a new instance of the ClassLogger class with the specified LoggerSettings.
        /// </summary>
        /// <remarks>
        /// Additionally sets up a LoggerLabel field to pass into the <see cref="LogContext"/>.
        /// </remarks>
        /// <param name="settings">The LoggerSettings to configure the logger's behavior.</param>
        /// <param name="loggerLabel"></param>
        internal ClassLogger(LoggerSettings settings, string loggerLabel) : base(settings)
        {
            _loggerLabel = loggerLabel;
        }

        private string DetermineLoggerLabel()
        {
            var callingType = new StackTrace(2).GetFrame(0).GetMethod().DeclaringType;

            if (callingType != null)
            {
                return callingType.Name;
            }

            return "Unknown";
        }

    }
}