using skner.Logging.OutputSettings.Abstracts;
using skner.Logging.OutputSettings.Common;
using skner.Logging.Tags;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Settings.OutputSettings
{
    /// <summary>
    /// Represents log output settings for saving log messages to a Xml file.
    /// </summary>
    [CreateAssetMenu(fileName = "XmlLogOutputSettings", menuName = "Logging/Log Output Settings/Xml File")]
    public class XmlLogOutputSettings : LogOutputSettings
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

            string xmlLog = ConvertToXml(filteredLogTagHolder);

            string buffer = LogOutputBuffer.AppendAndTryFlush(xmlLog + "\n");

            if (buffer != null)
            {
                buffer.TrimEnd('\n');
                await LogOutputFile.SaveToFileAsync(buffer);
            }
        }

        private string ConvertToXml(LogTagHolder logTagHolder)
        {
            var serializer = new XmlSerializer(typeof(LogTagHolder));
            var xmlBuilder = new StringBuilder();

            using (XmlWriter xmlWriter = XmlWriter.Create(xmlBuilder))
            {
                serializer.Serialize(xmlWriter, logTagHolder);
            }

            return xmlBuilder.ToString();
        }
    }
}