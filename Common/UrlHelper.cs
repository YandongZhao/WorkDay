using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace Comm
{
    public class UrlHelper
    {
        public static string LongToShortUrl(string longUrl)
        {
            string url = "http://api.t.sina.com.cn/short_url/shorten.xml";
            string datas = string.Format("source={0}&url_long={1}", "209678993", longUrl);
            byte[] byteArray = Encoding.UTF8.GetBytes(datas);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            //接收返回信息
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            return xml.SelectSingleNode("//url_short").InnerText;

        }
    }
}