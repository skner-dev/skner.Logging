using skner.Logging.Abstracts;
using skner.Logging.Exceptions;
using skner.Logging.Settings;
using UnityEngine;

namespace skner.Logging.Loggers
{
    /// <summary>
    /// The GlobalLogger is a singleton logger that can be used across the project. It can be called by using its static Instance.
    /// </summary>
    public class GlobalLogger : BaseLogger
    {

        private protected override string LoggerLabel => "Global";

        /// <summary>
        /// Provides access to the single instance of the GlobalLogger, allowing access to its logging functionality.
        /// </summary>
        public static GlobalLogger Instance;

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeGlobalLogger()
        {
            if (Instance != null) return;
            LoggerSettings globalLoggerSettings = LoggingSettingsProvider.GlobalLoggerSettings;
            if (globalLoggerSettings == null) throw new GlobalLoggerSettingsNotFoundException();
            if (globalLoggerSettings.Enabled)
            {
                Instance = new GlobalLogger(globalLoggerSettings);
            }
        }

        private GlobalLogger() : base() { }

        private GlobalLogger(LoggerSettings settings) : base(settings)
        {
        }
    }
}