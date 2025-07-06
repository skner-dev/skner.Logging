using skner.Logging.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace skner.Logging.OutputSettings.Common
{
    /// <summary>
    /// An Output Module that writes a log into a file.
    /// </summary>
    [Serializable]
    public class LogOutputFileWriter
    {

        /// <summary>
        /// The <see cref="LogPath"/> for the output file.
        /// </summary>
        public LogPath OutputPath;

        /// <summary>
        /// The name of the output file.
        /// </summary>
        public string OutputFileName;

        private string _fullOutput;

        public void SetupNewSession()
        {
            if (!Directory.Exists(OutputPath.GetCompletePath()))
            {
                Directory.CreateDirectory(OutputPath.GetCompletePath());
            }

            _fullOutput = OutputPath.GetCompletePath() + GetFullFileName();
        }

        public async Task SaveToFileAsync(string logData)
        {
            using var stream = new FileStream(_fullOutput, FileMode.Append, FileAccess.Write, FileShare.Read);
            using var writer = new StreamWriter(stream);
            await writer.WriteAsync(logData);
        }

        private string GetFullFileName()
        {
            string userDefinedFileName = OutputFileName;
            string suffix = "";

            // Check if the user-defined file name includes a suffix
            int suffixIndex = OutputFileName.LastIndexOf('.');
            if (suffixIndex != -1)
            {
                userDefinedFileName = OutputFileName.Substring(0, suffixIndex);
                suffix = OutputFileName.Substring(suffixIndex);
            }

            // Add timestamp to the file name
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileNameWithTimestamp = $"{userDefinedFileName}_{timestamp}";

            // Add the original suffix back (if any)
            return fileNameWithTimestamp + suffix;
        }
    }

}