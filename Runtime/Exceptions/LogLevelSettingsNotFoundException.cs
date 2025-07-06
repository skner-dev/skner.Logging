using System;

namespace skner.Logging.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the LogLevelSettings is not found.
    /// </summary>
    public class LogLevelSettingsNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the LogLevelSettingsNotFoundException class with a default message.
        /// </summary>
        public LogLevelSettingsNotFoundException() : base("LogLevelSettings was not found. Go to project settings to re-create it.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogLevelSettingsNotFoundException class with a custom message.
        /// </summary>
        /// <param name="message">A custom error message to describe the exception.</param>
        public LogLevelSettingsNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogLevelSettingsNotFoundException class with a custom message and an inner exception.
        /// </summary>
        /// <param name="message">A custom error message to describe the exception.</param>
        /// <param name="innerException">The inner exception that caused this exception.</param>
        public LogLevelSettingsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}