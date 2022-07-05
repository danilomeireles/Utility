using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Util
{
    /// <summary>
    /// A simple text file logger.
    /// </summary>
    public static class SimpleFileLogger
    {
        private static readonly string LogFilePath = @"C:\MyLogFile.txt";

        /// <summary>
        /// Add the provided text into the text file. If the file doesn't exist yet, this call will create it
        /// </summary>
        /// <param name="text">The text to add into the log file</param>
        /// <returns></returns>
        public static async Task Log(string text)
        {
            try
            {
                await using var writer = new StreamWriter(LogFilePath, true, Encoding.UTF8);
                await writer.WriteLineAsync($"[{DateTime.UtcNow:yyyy-MM-dd_HH:mm:ss}] {text}");
                await writer.FlushAsync();
            }
            catch
            {
                // ignore errors during the log saving process.
            }
        }
    }
}