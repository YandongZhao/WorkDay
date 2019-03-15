using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetWebFrom.Handler
{
    /// <summary>
    /// ContextReturn 的摘要说明
    /// </summary>
    public class ContextReturn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            context.Response.ContentType = "text/html";
            string jsonData = string.Empty;
            jsonData = "请正确填写电话！";// SubmitPhone(context);
            context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            string callback = context.Request.Params["callback"];
            context.Response.Write(callback + "({\"ResultStr\":\"" + jsonData + "\"})");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}