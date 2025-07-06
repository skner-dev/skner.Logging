using skner.Logging.Extensions;
using skner.Logging.Interfaces;
using skner.Logging.Models;
using skner.Logging.OutputSettings.Abstracts;
using skner.Logging.Settings;
using skner.Logging.Tags;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace skner.Logging.Abstracts
{
    /// <summary>
    /// The BaseLogger class defines abstract behaviour for any of the existing derived classes to use and share.
    /// </summary>
    public abstract class BaseLogger : ILoggingService
    {
        private readonly LoggerSettings _loggerSettings;

        public delegate void LogCallback(LogContext logContext);
        public event LogCallback OnLogMessage;

        public delegate Task LogCallbackAsync(LogContext logContext);
        public event LogCallbackAsync OnLogMessageAsync;

        private protected abstract string LoggerLabel { get; }

        private protected BaseLogger() { }

        private protected BaseLogger(LoggerSettings settings)
        {
            _loggerSettings = settings;
        }

        /// <inheritdoc/>
        [HideInCallstack]
        public void Log(string logLevel, string message)
        {
            if (!IsLogLevelSelected(_loggerSettings.SelectedLogLevels, logLevel)) return;

            LogContext logContext = GetLogContext(logLevel, message);
            LogTagHolder logTagHolder = GetLogTagHolder(logContext);

            if (_loggerSettings.LogToCallbacks)
            {
                if (OnLogMessageAsync != null)
                    foreach (LogCallbackAsync callback in OnLogMessageAsync.GetInvocationList().Cast<LogCallbackAsync>())
                        _ = callback.Invoke(logContext);
                if (OnLogMessage != null)
                    foreach (LogCallback callback in OnLogMessage.GetInvocationList().Cast<LogCallback>())
                        callback.Invoke(logContext);
            }

            if (_loggerSettings.LogToUnityConsole)
            {
                string log = LogTagInterpreter.FormatLog(logTagHolder, _loggerSettings.UnityConsoleLogFormat.Format);

                switch (logLevel)
                {
                    case "Error":
                        UnityEngine.Debug.LogError(log); break;
                    case "Warning":
                        UnityEngine.Debug.LogWarning(log); break;
                    default:
                        UnityEngine.Debug.Log(log); break;
                }
            }

            if (_loggerSettings.LogToExternal)
            {
                foreach (LogOutputSettings logOutputSettings in _loggerSettings.AssignedLogOutputs)
                {
                    logOutputSettings.SendToOutputAsync(logTagHolder).ConfigureAwait(false);
                }
            }
        }

        [HideInCallstack]
        private LogContext GetLogContext(string logLevel, string message)
        {
            var stackTrace = new StackTrace();
            StackFrame relevantFrame = null;
            var relevantFrames = new List<StackFrame>();

            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                MethodBase method = stackTrace.GetFrame(i).GetMethod();

                if (method != null)
                {
                    string declaringType = method.DeclaringType?.FullName;

                    if (declaringType != null && !method.IsDefined(typeof(HideInCallstackAttribute), true))
                    {
                        relevantFrame ??= new StackFrame(i, true);
                        relevantFrames.Add(new StackFrame(i, true));
                    }
                }
            }

            if (relevantFrame == null) throw new InvalidOperationException("No relevant stack frames were found. Is every code in the call stack marked with [HideInCallstack]?");

            return new LogContext()
            {
                Timestamp = DateTime.Now,
                LogLevel = LoggingSettingsProvider.LogLevelSettings.LogLevelDictionary[logLevel],
                Message = message,
                ClassName = relevantFrame.GetMethod().DeclaringType.FullName,
                MethodName = relevantFrame.GetMethod().Name,
                LineNumber = relevantFrame.GetFileLineNumber(),
                SourceLogger = LoggerLabel,
                StackFrames = relevantFrames
            };
        }

        [HideInCallstack]
        private LogTagHolder GetLogTagHolder(LogContext logContext)
        {
            return new LogTagHolder()
            {
                Timestamp = logContext.Timestamp.ToString(),
                LogLevelName = logContext.LogLevel.LogLevelName,
                LogLevelHexColor = ColorUtility.ToHtmlStringRGB(logContext.LogLevel.DisplayColor),
                Message = logContext.Message,
                ClassName = logContext.ClassName,
                MethodName = logContext.MethodName,
                LineNumber = logContext.LineNumber,
                SourceLogger = LoggerLabel,
                StackTrace = logContext.LogLevel.IncludeStackTrace ? logContext.StackFrames.ToStackString() : null
            };
        }

        [HideInCallstack]
        private bool IsLogLevelSelected(int selectedLogLevels, string logLevelToCheck)
        {
            if (LoggingSettingsProvider.LogLevelSettings.LogLevelDictionary.TryGetValue(logLevelToCheck, out var logLevelInfo))
            {
                return (selectedLogLevels & logLevelInfo.BitMask) != 0;
            }

            Log("Warning", $"LogLevel {logLevelToCheck} does not exist.");
            return false;
        }
    }
}