using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class WeChatPayException:Exception
    {
        public WeChatPayException(string msg) : base(msg)
        {

        }
    }
}
