using System;
using System.Text;
using UnityEngine;

namespace skner.Logging.OutputSettings.Common
{
    /// <summary>
    /// An Output Module that creates a writting buffer for the log output.
    /// </summary>
    [Serializable]
    public class LogOutputBuffer
    {
        /// <summary>
        /// Enables or disables the buffer.
        /// </summary>
        public bool IsBufferEnabled;

        /// <summary>
        /// Determines the flushing interval in seconds.
        /// </summary>
        public float FlushInterval;

        /// <summary>
        /// The maximum size of the buffer before force flushing.
        /// </summary>
        public int BufferLengthInterval;

        private readonly StringBuilder _logBuffer = new StringBuilder();
        private DateTime _lastFlushTime;

        /// <summary>
        /// Appends the specified message to the buffer and, if necessary, flushes the buffer by returning it.
        /// </summary>
        /// <param name="message">The message to append to the buffer.</param>
        /// <returns>If the buffer is flushed, returns the buffer data which includes the given <paramref name="message"/>; otherwise, returns null.</returns>
        public string AppendAndTryFlush(string message)
        {
            if (!IsBufferEnabled) { return message; }

            _logBuffer.Append(message);
            if (ShouldFlushBuffer())
            {
                _lastFlushTime = DateTime.Now;
                string bufferData;
                lock (_logBuffer)
                {
                    bufferData = _logBuffer.ToString();
                    _logBuffer.Clear();
                }

                return bufferData;
            }
            else
            {
                return null;
            }
        }

        private bool ShouldFlushBuffer()
        {
            bool isBufferFull = _logBuffer.Length >= BufferLengthInterval;
            bool isTimeToFlush = DateTime.Now - _lastFlushTime >= TimeSpan.FromSeconds(FlushInterval);
            return isBufferFull || isTimeToFlush;
        }
    }

}