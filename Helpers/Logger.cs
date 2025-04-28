using System;
using System.IO;

namespace Estore.Ce
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        private static readonly string LogFilePath = Path.Combine(LogDirectory, "error_log.txt");
        private static readonly long MaxLogSizeBytes = 100 * 1024; // 100 KB limit

        public static void Log(string message)
        {
            try
            {
                RotateLogIfNeeded();

                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + message);
                }
            }
            catch
            {
                // Fail silently on log failure
            }
        }

        public static void Log(Exception ex)
        {
            Log("Exception: " + ex.Message + "\nStack Trace:\n" + ex.StackTrace);
        }

        private static void RotateLogIfNeeded()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    FileInfo fi = new FileInfo(LogFilePath);
                    if (fi.Length > MaxLogSizeBytes)
                    {
                        string backupName = Path.Combine(LogDirectory,
                            "error_log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak");

                        File.Move(LogFilePath, backupName);
                    }
                }
            }
            catch
            {
                // Silent catch – don't let rotation failure break the app
            }
        }
    }
}
