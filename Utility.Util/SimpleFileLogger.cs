using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Util
{    
    public static class SimpleFileLogger
    {
        private static readonly string LogFilePath = @"C:\MyLogFile.txt";
        
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