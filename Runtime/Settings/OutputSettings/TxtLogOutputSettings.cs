using skner.Logging.Extensions;
using skner.Logging.OutputSettings.Abstracts;
using skner.Logging.OutputSettings.Common;
using skner.Logging.Tags;
using System.Threading.Tasks;
using UnityEngine;

namespace skner.Logging.OutputSettings
{
    /// <summary>
    /// Represents log output settings for saving log messages to a text (TXT) file.
    /// </summary>
    [CreateAssetMenu(fileName = "TxtLogOutputSettings", menuName = "Logging/Log Output Settings/Txt File")]
    public sealed class TxtLogOutputSettings : LogOutputSettings
    {

        [SerializeField] internal LogOutputFormat LogOutputFormat;
        [SerializeField] internal LogOutputFileWriter LogOutputFile;
        [SerializeField] internal LogOutputBuffer LogOutputBuffer;

        private void OnEnable()
        {
            LogOutputFile.SetupNewSession();
        }

        /// <inheritdoc/>
        public override async Task SendToOutputAsync(LogTagHolder logTagHolder)
        {
            string logToSave = LogOutputFormat.FormatLog(logTagHolder);
            string formattedLogToSave = $"{logToSave}\n";

            string buffer = LogOutputBuffer.AppendAndTryFlush(formattedLogToSave);
            if (buffer != null) await LogOutputFile.SaveToFileAsync(buffer);
        }
    }
}