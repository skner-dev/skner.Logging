using skner.Logging.OutputSettings.Abstracts;
using skner.Logging.OutputSettings.Common;
using skner.Logging.Tags;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Settings.OutputSettings
{
    /// <summary>
    /// Represents log output settings for saving log messages to a Csv file.
    /// </summary>
    [CreateAssetMenu(fileName = "CsvLogOutputSettings", menuName = "Logging/Log Output Settings/Csv File")]
    public class CsvLogOutputSettings : LogOutputSettings
    {

        [SerializeField] internal LogOutputSelector LogContextSelector;
        [SerializeField] internal LogOutputFileWriter LogOutputFile;
        [SerializeField] internal LogOutputBuffer LogOutputBuffer;

        private void OnEnable()
        {
            LogOutputFile.SetupNewSession();
        }

        /// <inheritdoc/>
        public override async Task SendToOutputAsync(LogTagHolder logTagHolder)
        {
            LogTagHolder filteredLogTagHolder = LogContextSelector.FilterAndConvertToObject(logTagHolder);

            string csvLog = ConvertToCsv(filteredLogTagHolder);

            string buffer = LogOutputBuffer.AppendAndTryFlush(csvLog + "\n");

            if (buffer != null)
            {
                buffer.TrimEnd('\n');
                await LogOutputFile.SaveToFileAsync(buffer);
            }
        }

        private string ConvertToCsv(LogTagHolder logTagHolder)
        {
            return $"{EscapeCsvField(logTagHolder.Timestamp)}, {EscapeCsvField(logTagHolder.LogLevelName)}, " +
                   $"{EscapeCsvField(logTagHolder.SourceLogger)}, {logTagHolder.LineNumber}, " +
                   $"{EscapeCsvField(logTagHolder.ClassName)}, {EscapeCsvField(logTagHolder.MethodName)}, " +
                   $"{EscapeCsvField(logTagHolder.Message)}, {EscapeCsvField(logTagHolder.StackTrace)}";
        }

        private string EscapeCsvField(string field)
        {
            return $"\"{field?.Replace("\"", "\"\"") ?? string.Empty}\"";
        }
    }
}