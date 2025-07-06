using System;
using UnityEngine;

namespace skner.Logging.Models
{
    /// <summary>
    /// Represents a structure that defines details for a log level.
    /// </summary>
    [Serializable]
    public struct LogLevelDetail
    {
        /// <summary>
        /// The name of the log level.
        /// </summary>
        public string LogLevelName;

        /// <summary>
        /// The severity of the log level.
        /// </summary>
        public int Severity;

        /// <summary>
        /// The color used to display log messages of this level.
        /// </summary>
        public Color DisplayColor;

        /// <summary>
        /// Determines if the StackTrace should be included at this LogLevel.
        /// </summary>
        public bool IncludeStackTrace;

        internal readonly bool IsEditable => LogLevelName != "Error" && LogLevelName != "Warning" && LogLevelName != "Debug";

        internal int BitMask;

        internal LogLevelDetail(string logLevelName, int severity, Color displayColor, bool includeStackTrace)
        {
            LogLevelName = logLevelName;
            Severity = severity;
            DisplayColor = displayColor;
            IncludeStackTrace = includeStackTrace;
            BitMask = 0;
        }
    }
}