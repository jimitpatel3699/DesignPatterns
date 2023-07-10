using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP22.Handler
{
    public class Logger
    {
        private string _logPath = @"C:\Users\jimit\Desktop\.net\DesignPatterns\DataAccessLayer\logs.txt";
        private List<string> _logQueue = new List<string>(); // Queue to hold log messages

        public void Log(string message)
        {
            EnqueueLog("[Info]", message);
        }

        public void ErrorLog(string message)
        {
            EnqueueLog("[Error]", message);
        }

        private void EnqueueLog(string logType, string message)
        {
            string formatMessage = $"{DateTime.Now} : {message}";
            string logEntry = $"Type: {logType} {formatMessage}";

            _logQueue.Add(logEntry);
            FlushLogQueue();
        }

        private void FlushLogQueue()
        {
            using (StreamWriter sr = File.AppendText(_logPath))
            {
                try
                {
                    foreach (string logEntry in _logQueue)
                    {
                        sr.WriteLine(logEntry);
                    }
                    _logQueue.Clear();
                }
                catch (Exception ex)
                {
                    string errorLogEntry = $"An exception has occurred: {ex.Message}";
                    sr.WriteLine(errorLogEntry);
                }
            }
        }
    }

}