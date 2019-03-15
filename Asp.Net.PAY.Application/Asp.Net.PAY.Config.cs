using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.PAY.Application
{
    public class PAYApplicationConfig
    {

        /// <summary>
        /// =======【日志级别】===================================
        /// 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        /// </summary>
        public static int LOG_LEVENL { get; set; }

    }
}
