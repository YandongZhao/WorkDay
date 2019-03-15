using Abp.Net.Sms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.CoreApp
{
    public class SmsSenderConfiguration : ISmsSenderConfiguration
    {
        public string GetAppKey()
        {
            return "LTAIp8NRtmHYfp7S";
        }

        public string GetAppSecret()
        {
            return "kMLNQh6SYVv8GK1XwjzeIw0hxs2rv9";
        }

        public string GetDefaultFreeSignName()
        {
            return "西域新丝路";
        }

        public string GetDefaultSmsTemplateCode()
        {
            return "SMS_135035369";
        }

        public string GetServiceUrl()
        {
            return "";
        }
    }
}
