using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetApp
{
    /// <summary>
    /// 消息发送帮助类
    /// </summary>
    public  class SMSHelper
    {
        private string Account { get; set; }// = "N2361053";
        private string PassWord { get; set; }//= "Ly1ZF8UMVQ7a92";
        private string Url { get; set; }
        public SMSHelper(string url,string account, string passWord)
        {
            Url = url;
            Account = account;
            PassWord = passWord;
        }

        public string Send(string phone, string template)
        {

            string postJsonTpl = "\"account\":\"{0}\",\"password\":\"{1}\",\"phone\":\"{2}\",\"report\":\"false\",\"msg\":\"{3}\"";
            string jsonBody = string.Format(postJsonTpl, Account, PassWord, phone, template);
            string result = doPostMethodToObj(Url, "{" + jsonBody + "}");

            return result;
        }
        public static string doPostMethodToObj(string url, string jsonBody)
        {
            string result = String.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            // Create NetworkCredential Object 
            NetworkCredential admin_auth = new NetworkCredential("username", "password");

            // Set your HTTP credentials in your request header
            httpWebRequest.Credentials = admin_auth;

            // callback for handling server certificates
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
                streamWriter.Flush();
                streamWriter.Close();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }

    }
}
