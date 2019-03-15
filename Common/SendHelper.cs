using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetApp
{
   public  class SendHelper
    {
        public static string _url;
        public SendHelper(string url)
        {
            _url = url;
        }
        public  string HttpPost(string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);//new
            byte[] dat = Encoding.UTF8.GetBytes(postDataStr);
            request.Method = "POST";

            request.ContentType = "application/json; charset=utf-8";//
            request.ContentLength = dat.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(dat, 0, dat.Length);
            myRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream ?? throw new InvalidOperationException(), Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
   
}
