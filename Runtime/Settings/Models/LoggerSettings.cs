using skner.Logging.Models;
using skner.Logging.OutputSettings.Abstracts;
using System.Collections.Generic;
using UnityEngine;

namespace skner.Logging.Settings
{
    /// <summary>
    /// A ScriptableObject that represents logger settings.
    /// </summary>
    [CreateAssetMenu(fileName = "LoggerSettings", menuName = "Logging/Logger Settings")]
    public class LoggerSettings : ScriptableObject
    {
        [Header("Main Settings")]
        public bool Enabled;

        public string Name;

        [Header("Output Options")]
        public bool LogToUnityConsole;
        public LogFormat UnityConsoleLogFormat;

        public bool LogToExternal;
        public List<LogOutputSettings> AssignedLogOutputs;

        public bool LogToCallbacks;

        [Header("Filtering Options")]
        public int SelectedLogLevels;

        private void OnEnable()
        {
            AssignedLogOutputs ??= new List<LogOutputSettings>();
        }
    }

}