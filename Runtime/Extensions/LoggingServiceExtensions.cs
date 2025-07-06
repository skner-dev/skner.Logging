using skner.Logging.Interfaces;
using UnityEngine;

namespace skner.Logging.Extensions
{
    /// <summary>
    /// A static class containing extension methods for the <see cref="ILoggingService"/> interface to log messages with different log levels.
    /// </summary>
    /// <remarks>
    /// These methods provide convenient ways to log messages using the base default log levels: Debug, Warning, and Error.
    /// </remarks>
    public static class LoggingServiceExtensions
    {
        /// <summary>
        /// Logs a message with the base "Debug" log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILoggingService"/> instance used for logging.</param>
        /// <param name="message">The message to log.</param>
        [HideInCallstack]
        public static void LogDebug(this ILoggingService logger, string message) => logger.Log("Debug", message);

        /// <summary>
        /// Logs a message with the base "Warning" log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILoggingService"/> instance used for logging.</param>
        /// <param name="message">The message to log.</param>
        [HideInCallstack]
        public static void LogWarning(this ILoggingService logger, string message) => logger.Log("Warning", message);

        /// <summary>
        /// Logs a message with the base "Error" log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILoggingService"/> instance used for logging.</param>
        /// <param name="message">The message to log.</param>
        [HideInCallstack]
        public static void LogError(this ILoggingService logger, string message) => logger.Log("Error", message);
    }
}