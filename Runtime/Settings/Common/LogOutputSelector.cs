using skner.Logging.Tags;
using System;

namespace skner.Logging.OutputSettings.Common
{
    [Flags]
    public enum LogContextFields
    {
        Timestamp = 1 << 0,
        LogLevel = 1 << 1,
        SourceLogger = 1 << 2,
        LineNumber = 1 << 3,
        ClassName = 1 << 4,
        MethodName = 1 << 5,
        Message = 1 << 6,
        StackTrace = 1 << 7
    }

    /// <summary>
    /// An Output Module that filters a <see cref="LogTagHolder"/> to only include certain fields.
    /// </summary>
    [Serializable]
    public class LogOutputSelector
    {

        /// <summary>
        /// A list of fields to be included, using <see cref="FlagsAttribute"/>.
        /// </summary>
        public LogContextFields IncludedFields;

        /// <summary>
        /// Filters the given <see cref="LogTagHolder"/> by the configured <see cref="IncludedFields"/>.
        /// </summary>
        /// <param name="logTagHolder"></param>
        /// <returns>The new <see cref="LogTagHolder"/> with the filtered fields.</returns>
        public LogTagHolder FilterAndConvertToObject(LogTagHolder logTagHolder)
        {
            return new LogTagHolder
            {
                Timestamp = (IncludedFields & LogContextFields.Timestamp) != 0 ? logTagHolder.Timestamp : null,
                LogLevelName = (IncludedFields & LogContextFields.LogLevel) != 0 ? logTagHolder.LogLevelName : null,
                SourceLogger = (IncludedFields & LogContextFields.SourceLogger) != 0 ? logTagHolder.SourceLogger : null,
                LineNumber = (IncludedFields & LogContextFields.LineNumber) != 0 ? logTagHolder.LineNumber : null,
                ClassName = (IncludedFields & LogContextFields.ClassName) != 0 ? logTagHolder.ClassName : null,
                MethodName = (IncludedFields & LogContextFields.MethodName) != 0 ? logTagHolder.MethodName : null,
                Message = (IncludedFields & LogContextFields.Message) != 0 ? logTagHolder.Message : null,
                StackTrace = (IncludedFields & LogContextFields.StackTrace) != 0 ? logTagHolder.StackTrace : null
            };
        }
    }

}