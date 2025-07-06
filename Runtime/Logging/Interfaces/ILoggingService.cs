namespace skner.Logging.Interfaces
{
    /// <summary>
    /// Defines an interface for any Logger used.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Logs a message with the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level of the message.</param>
        /// <param name="message">The message to be logged.</param>
        public void Log(string logLevel, string message);
    }
}