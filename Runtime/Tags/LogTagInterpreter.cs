using System.Reflection;

namespace skner.Logging.Tags
{
    /// <summary>
    /// Provides a utility for formatting log messages by replacing placeholders with values from a LogTagHolder.
    /// </summary>
    public static class LogTagInterpreter
    {
        /// <summary>
        /// Formats a log message string by replacing placeholder tags with corresponding values from a <see cref="LogTagHolder"/>.
        /// </summary>
        /// <param name="logTagHolder">The LogTagHolder containing tag-value pairs.</param>
        /// <param name="formatString">The log message format string with tags to replace.</param>
        /// <returns>The formatted log message with replaced tag values.</returns>
        public static string FormatLog(LogTagHolder logTagHolder, string formatString)
        {
            PropertyInfo[] properties = logTagHolder.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                string tag = $"{{{property.Name}}}";
                string value = property.GetValue(logTagHolder)?.ToString() ?? string.Empty;
                formatString = formatString.Replace(tag, value);
            }

            return formatString;
        }
    }
}