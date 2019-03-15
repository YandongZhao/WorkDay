using System;
using System.Collections.Generic;
using System.Text;

namespace WeChatPay.Model
{
    /// <summary>
    /// =======【基本信息设置】=====================================
    /// 微信公众号信息配置
    /// APPID：绑定支付的APPID（必须配置）
    /// </summary>
    public class WeChatPayConfig
    {

        /// <summary>
        /// APPID：绑定支付的APPID（必须配置）
        /// </summary>
        public static object APPID { get; set; }
        /// <summary>
        /// APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        public static object APPSECRET { get; set; }
        /// <summary>
        /// KEY：商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public static string KEY { get; set; }
        /// <summary>
        /// MCHID：商户号（必须配置）
        /// </summary>
        public static object MCHID { get; set; }



        /// <summary>
        ///   =======【证书路径设置】===================================== 
        ///证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        /// </summary>
        public static string SSLCERT_PATH { get; set; }
        public static string SSLCERT_PASSWORD { get; set; }


        /// <summary>
        /// =======【支付结果通知url】===================================== 
        ///   支付结果通知回调url，用于商户接收支付结果
        /// </summary>
        public static object NOTIFY_URL { get; set; }

        
        /// <summary>
        /// =======【商户系统后台机器IP】===================================== 
        /// 此参数可手动配置也可在程序中自动获取
        /// </summary>
        public static object IP { get; set; }


        /// <summary>
        /// =======【日志级别】===================================
        /// 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        /// </summary>
        public static int LOG_LEVENL { get; set; }

       
        /// <summary>
        /// =======【代理服务器设置】===================================
        /// 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        /// </summary>
        public static string PROXY_URL { get; set; }
        
        /// <summary>
        /// =======【上报信息配置】===================================
        /// 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        /// </summary>
        public static int REPORT_LEVENL { get; set; }


        public static string Jsapi_ticketUrl { get; set; }
    }
}
