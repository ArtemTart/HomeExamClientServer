using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeExamClientServer
{
    class MyLogger
    {
        public static string dirLocation = @"..\\logs";
        public static object mutex;
        public MyLogger()
        {
            mutex = new object();
            if (!Directory.Exists(dirLocation))
                Directory.CreateDirectory(dirLocation);
        }
        public async static Task Log(string logMessage)
        {
            try
            {
                var logFilePath = Path.Combine(dirLocation, "Log.txt");
                await Task.Factory.StartNew(() => WriteToLog(logMessage, logFilePath));
                
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }
        }
        static  void WriteToLog(string logMessage, string logFilePath)
        {
            lock (mutex)
            {
                 File.AppendAllTextAsync(logFilePath, string.Format($"{DateTime.Now}  Message: {logMessage} + current thread id is {Thread.CurrentThread.ManagedThreadId} \n"));
            }
           
        }
    }

}

