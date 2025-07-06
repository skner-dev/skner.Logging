using skner.Logging.Interfaces;
using skner.Logging.Settings;
using UnityEngine;

namespace skner.Logging.Loggers
{
    /// <summary>
    /// The GameObjectLogger is a Unity component that allows logging messages as part of the Unity scene.
    /// </summary>
    /// <remarks>
    /// It can be attached to any GameObject to log messages using the provided LoggerSettings.
    /// </remarks>
    public class GameObjectLogger : MonoBehaviour, ILoggingService
    {

        public LoggerSettings LoggerSettings;

        private ClassLogger _logger;

        private void Awake()
        {
            _logger = new ClassLogger(LoggerSettings, gameObject.name);
        }

        /// <inheritdoc/>
        [HideInCallstack]
        public void Log(string logLevel, string message)
        {
            _logger.Log(logLevel, message);
        }
    }
}