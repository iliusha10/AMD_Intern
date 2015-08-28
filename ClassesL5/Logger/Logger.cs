using System;
using System.IO;
using System.Text;

namespace Logger
{
    public static class Logger
    {
        private static void SaveLogToFile(string message)
        {
            using (
                FileStream fs = new FileStream(@"C:\Users\ilia.dermenji\Downloads\Assignment\ClassesL5\LogFile.txt",
                    FileMode.Append))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(message);
                fs.Write(info, 0, info.Length);
            }
        }

        public static void AddToLog(string message)
        {
            string log = String.Format("{0}, {1} \r\n", DateTime.Now, message);
            SaveLogToFile(log);
        }
    }
}