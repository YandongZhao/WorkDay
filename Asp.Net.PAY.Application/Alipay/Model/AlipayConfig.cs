using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.PAY.Application.Alipay.Model
{
    public class AlipayConfig
    {
        /// <summary>
        /// 请求链接
        /// </summary>
          public string serverUrl       {get;set;}
        /// <summary>
        /// 应用Id
        /// </summary>
          public string appId           {get;set;}
        /// <summary>
        /// 私钥
        /// </summary>
          public string privateKeyPem   {get;set;}
        /// <summary>
        /// 请求类型
        /// </summary>
          public string format          {get;set;}
        /// <summary>
        /// 版本号
        /// </summary>
          public string version         {get;set;}
        /// <summary>
        /// 签名类型
        /// </summary>
          public string signType        {get;set;}
        /// <summary>
        /// 支付公钥
        /// </summary>
          public string alipayPulicKey  {get;set;}
        /// <summary>
        /// 编码方式
        /// </summary>
          public string charset         {get;set;}
        /// <summary>
        /// key来自文件？
        /// </summary>
          public bool keyFromFile { get; set; }
    }
}
