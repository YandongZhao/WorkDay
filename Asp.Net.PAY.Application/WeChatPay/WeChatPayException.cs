using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.PAY.Application.WeChatPay
{
    public class WeChatPayException:Exception
    {
        public WeChatPayException(string msg) : base(msg)
        {

        }
    }
}
