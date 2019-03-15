using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class LogHelper
    {
        public static void WriteLog(logEntity entity)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\LogFile\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + DateTime.Now.ToString("yyyy-MM-dd") + ".log.txt";
            StringBuilder str = new StringBuilder();
            str.Append("---  时间:    " + entity.Time.ToString() + "\r\n");
            str.Append("---  行为:  " + entity.Reseon + "\r\n");
            str.Append("---  内容: " + entity.logContent + "\r\n");
            str.Append("-----------------------------------------------------------\r\n\r\n");
            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
    }

    public class logEntity
    {
        public DateTime Time { get; set; }

        public string Reseon { get; set; }

        public string logContent { get; set; }
    }
}
