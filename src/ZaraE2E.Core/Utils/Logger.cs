using System;
using System.IO;

namespace ZaraE2E.Core.Utils
{
    public static class Logger
    {
        private static readonly string logFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestLogs", $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

        static Logger()
        {
            var logDir = Path.GetDirectoryName(logFilePath);
            if (string.IsNullOrEmpty(logDir))
            {
                logDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }

        public static void Warn(string message)
        {
            WriteLog("WARN", message);
        }

        public static void Error(string message, Exception ex = null)
        {
            WriteLog("ERROR", message + (ex != null ? $" | Exception: {ex}" : ""));
        }

        private static void WriteLog(string level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            Console.WriteLine(logMessage);
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
