using skner.Logging.Models;
using skner.Logging.Tags;
using System.Threading.Tasks;
using UnityEngine;

namespace skner.Logging.OutputSettings.Abstracts
{
    /// <summary>
    /// The base class for log output settings. Derived classes define how log messages are sent to specific outputs, such as files or external systems.
    /// </summary>
    public abstract class LogOutputSettings : ScriptableObject
    {

        /// <summary>
        /// Sends a log message to the configured output asynchronously.
        /// </summary>
        /// <param name="logTagHolder">The <see cref="LogTagHolder"/> to be sent.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public abstract Task SendToOutputAsync(LogTagHolder logTagHolder);

        internal protected LogOutputSettings() { }
    }
}