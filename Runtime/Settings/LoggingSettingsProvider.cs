using skner.Logging.Exceptions;
using skner.Logging.Loggers;
using UnityEngine;

namespace skner.Logging.Settings
{
    /// <summary>
    /// A static class that provides access to the singleton settings.
    /// </summary>
    public static class LoggingSettingsProvider
    {

        private const string LOG_LEVEL_SETTINGS_RESOURCE_PATH = "skner's Logging/LogLevelSettings";
        private const string GLOBAL_LOGGER_SETTINGS_RESOURCE_PATH = "skner's Logging/GlobalLoggerSettings";

        private static LogLevelSettings _logLevelSettings;
        /// <summary>
        /// Returns the project settings that contain the Log Levels.
        /// </summary>
        public static LogLevelSettings LogLevelSettings
        {
            get
            {
                if (_logLevelSettings == null)
                {
                    _logLevelSettings = Resources.Load<LogLevelSettings>(LOG_LEVEL_SETTINGS_RESOURCE_PATH);
                }
                if (_logLevelSettings == null) { throw new LogLevelSettingsNotFoundException(); }
                return _logLevelSettings;
            }
        }

        private static LoggerSettings _globalLoggerSettings;
        /// <summary>
        /// Returns the project settings that contains the Logger Settings for the <see cref="GlobalLogger"/>.
        /// </summary>
        public static LoggerSettings GlobalLoggerSettings
        {
            get
            {
                if (_globalLoggerSettings == null)
                {
                    _globalLoggerSettings = Resources.Load<LoggerSettings>(GLOBAL_LOGGER_SETTINGS_RESOURCE_PATH);
                }
                if (_globalLoggerSettings == null) { throw new GlobalLoggerSettingsNotFoundException(); }
                return _globalLoggerSettings;
            }
        }
    }
}