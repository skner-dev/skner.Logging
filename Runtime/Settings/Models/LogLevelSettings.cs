using skner.Logging.Models;
using System.Collections.Generic;
using UnityEngine;

namespace skner.Logging.Settings
{
    /// <summary>
    /// A ScriptableObject that represents the log level settings.
    /// </summary>
    public class LogLevelSettings : ScriptableObject
    {

        /// <summary>
        /// An array of LogLevelDetails representing the individual log levels and their properties.
        /// </summary>
        public LogLevelDetail[] LogLevels;

        /// <summary>
        /// A dictionary that provides quick access to log level details by their names.
        /// </summary>
        public Dictionary<string, LogLevelDetail> LogLevelDictionary { get; private set; }

        private void OnEnable()
        {
            LogLevels ??= new LogLevelDetail[0];

            LogLevelDictionary = new Dictionary<string, LogLevelDetail>();
            
            for (int i = 0; i < LogLevels.Length; i++)
            {
                LogLevels[i].BitMask = 1 << i;
                LogLevelDictionary[LogLevels[i].LogLevelName] = LogLevels[i];
            }
        }
    }

}