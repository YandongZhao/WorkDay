﻿using Asp.Net.PAY.Application.WeChatPay.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Asp.Net.PAY.Application
{
    /// <summary>
    /// 支付日志记录类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 在网站根目录下创建日志目录
        /// </summary>
        public static string path = AppContext.BaseDirectory + "logs";

        /// <summary>
        /// 向日志文件写入调试信息
        /// @param className 类名
        /// @param content 写入内容
        /// </summary>
        /// <param name="className"></param>
        /// <param name="content"></param>
        public static void Debug(string className, string content)
        {
            if (WeChatPayConfig.LOG_LEVENL >= 3)
            {
                WriteLog("DEBUG", className, content);
            }
        }

        /// <summary>
        /// 向日志文件写入运行时信息
        /// @param className 类名
        /// @param content 写入内容
        /// </summary>
        /// <param name="className"></param>
        /// <param name="content"></param>
        public static void Info(string className, string content)
        {
            if (WeChatPayConfig.LOG_LEVENL >= 2)
            {
                WriteLog("INFO", className, content);
            }
        }

        /// <summary>
        /// 向日志文件写入出错信息
        /// @param className 类名
        /// @param content 写入内容
        /// </summary>
        /// <param name="className"></param>
        /// <param name="content"></param>
        public static void Error(string className, string content)
        {
            if (WeChatPayConfig.LOG_LEVENL >= 1)
            {
                WriteLog("ERROR", className, content);
            }
        }

        /// <summary>
        /// 实际的写日志操作
        /// @param type 日志记录类型
        /// @param className 类名
        /// @param content 写入内容
        /// </summary>
        /// <param name="type"></param>
        /// <param name="className"></param>
        /// <param name="content"></param>
        protected static void WriteLog(string type, string className, string content)
        {
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw = File.AppendText(filename);

            //向日志文件写入内容
            string write_content = time + " " + type + " " + className + ": " + content;
            mySw.WriteLine(write_content);

            //关闭日志文件
            mySw.Close();
        }
    }
}
