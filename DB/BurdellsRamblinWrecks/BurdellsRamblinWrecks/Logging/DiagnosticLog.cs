using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BurdellsRamblinWrecks.Logging
{
    class DiagnosticLog
    {
        public static string LogPath { set; get; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/CS6400/";
        public static string LogPrefix { set; get; } = @"BurdellsDiags";
        static readonly object _locker = new object();
        private static string sToday;
        public static void Log(string logMessage)
        {
            try
            {
                sToday = DateTime.Now.ToString("yyyy-MM-dd");
                var logFileName = LogPrefix + " " + sToday + ".txt";
                var logFilePath = Path.Combine(LogPath, logFileName);

                // Try to ensure our directory exists
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(logFilePath);

                //Use this for daily log files : "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                WriteToLog(logMessage, logFilePath);
            }
            catch (Exception e)
            {
                //log log-exception to the console if we can't write it to the file
                Console.WriteLine($"EventLog Can Not Write Value {logMessage}, Exception {e.ToString()}");
            }
        }

        static void WriteToLog(string logMessage, string logFilePath)
        {
            lock (_locker)
            {
                File.AppendAllText(logFilePath,
                        string.Format("{0}, {1}, {2}{3}",
                        sToday, DateTime.Now.ToString("HH:mm:ss.fff"),
                        logMessage, Environment.NewLine));
            }
        }
    }


}
