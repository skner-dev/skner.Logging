using skner.Logging.Extensions;
using skner.Logging.Models;
using skner.Logging.Tags;
using System;

namespace skner.Logging.OutputSettings.Common
{
    /// <summary>
    /// An Output Module that formats the Log with a given <see cref="LogFormat"/>
    /// </summary>
    [Serializable]
    public class LogOutputFormat
    {

        /// <summary>
        /// The format used for log messages in this output setting.
        /// </summary>
        public LogFormat Format;

        /// <summary>
        /// Determines whether rich text tags should be retained in log messages.
        /// </summary>
        public bool KeepRichText;

        /// <summary>
        /// Formats a log based on a given <see cref="LogTagHolder"/> and the configuration params.
        /// </summary>
        /// <param name="logTagHolder"></param>
        /// <returns>The formatted log string.</returns>
        public string FormatLog(LogTagHolder logTagHolder)
        {
            string log = LogTagInterpreter.FormatLog(logTagHolder, Format.Format);
            return KeepRichText ? log : log.WithoutRichTextTags();
        }

    }

}