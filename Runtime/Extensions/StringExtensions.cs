using System.Text.RegularExpressions;

namespace skner.Logging.Extensions
{
    /// <summary>
    /// A collection of extension methods for string manipulation.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Removes Rich Text tags from the input string.
        /// </summary>
        /// <param name="input">The input string that may contain Rich Text tags.</param>
        /// <returns>A string with Rich Text tags removed.</returns>
        internal static string WithoutRichTextTags(this string input)
        {
            // Check if the input string is null or empty
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Define a regular expression pattern to match HTML-like tags
            string pattern = @"<[^>]*>";

            // Use regular expression to replace matched tags with an empty string
            string result = Regex.Replace(input, pattern, string.Empty);

            return result;
        }
    }
}