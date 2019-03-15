using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace WeChatComm
{
    public class WeChatApi
    {
        #region 获取OpenId
        /// <summary>
        /// 获取OpenId
        /// </summary>
        public static string GetOpenID(string appid, string redirect_url, string code, string screct)
        {
            string strJson = "";
            if (string.IsNullOrEmpty(code))
            {
                redirect_url = HttpUtility.UrlEncode(redirect_url);
                HttpContext.Current.Response.Redirect(string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect",
                   appid, redirect_url, new Random().Next(1000, 200000).ToString()));
            }
            else
            {
                strJson = HttpPost(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
               appid, screct, code),null);
            }
            return JsonConvert.DeserializeObject(strJson).ToString();
        }
        #endregion

        #region 获取access_token

        public static Access_token GetAccessTokenFromServer(string appid, string appSecret)
        {
            string jsonStr = WeChatApi.HttpGet(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, appSecret));
            Access_token token = new Access_token();
            token = JsonHelper.ParseFromJson<Access_token>(jsonStr);
            return token;
        }

        #endregion

        #region 验证Token是否过期
        /// <summary>
        /// 验证Token是否过期
        /// </summary>
        public static bool TokenExpired(string access_token)
        {
            //string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token);
            //string jsonStr = HttpPost(url, null);//HttpRequestUtil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token));
            
            return false;
        }
        #endregion

        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static string GetUserInfo(string access_token, string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}", access_token, openid);
            string strJson = HttpGet(url);// HttpRequestUtil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}", access_token, openid));
            return strJson;
        }

       
        #endregion

        public static string HttpGet(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                return content;
            }

        }
        public static string HttpPost(string url,string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//new
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
