using System;

namespace skner.Logging.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the GlobalLoggerSettings is not found.
    /// </summary>

    public class GlobalLoggerSettingsNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the GlobalLoggerSettingsNotFoundException class with a default message.
        /// </summary>
        public GlobalLoggerSettingsNotFoundException() : base("GlobalLoggerSettings was not found. Go to project settings to re-create it.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the GlobalLoggerSettingsNotFoundException class with a custom message.
        /// </summary>
        /// <param name="message">A custom error message to describe the exception.</param>
        public GlobalLoggerSettingsNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GlobalLoggerSettingsNotFoundException class with a custom message and an inner exception.
        /// </summary>
        /// <param name="message">A custom error message to describe the exception.</param>
        /// <param name="innerException">The inner exception that caused this exception.</param>
        public GlobalLoggerSettingsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}