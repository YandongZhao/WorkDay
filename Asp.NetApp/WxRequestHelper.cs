using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace WeChatComm
{
    public class WxRequestHelper
    {
        private static string _appId;
        private static string _appSecret;
        public WxRequestHelper(string appId,string appSecret)
        {
            _appId = appId;
            _appSecret = appSecret;
        }

        #region 获取OpenID
        /// <summary>
        /// 获取OpenID
        /// </summary>
        public  string GetOpenID(string redirect_url, string code)
        {
            string openid = "";
            openid = WeChatApi.GetOpenID(_appId, redirect_url, code, _appSecret);
            return openid;
        }
        #endregion

        #region 获取access_token
        /// <summary>
        /// 获取access_token
        /// </summary>
        public  string GetAccessToken()
        {
            
            string Token = string.Empty;
            DateTime validDate;
            // 读取XML文件
            string filepath ="Cache/token.xml";

            StreamReader str = new StreamReader(filepath, System.Text.Encoding.UTF8);
            XmlDocument xml = new XmlDocument();
            xml.Load(str);
            str.Close();
            str.Dispose();
            Token = xml.SelectSingleNode("xml").SelectSingleNode("Access_Token").InnerText;
            validDate = Convert.ToDateTime(xml.SelectSingleNode("xml").SelectSingleNode("Access_endTime").InnerText);

            if (DateTime.Now > validDate)
            {
                DateTime _youxrq = DateTime.Now;
                Access_token mode =WeChatApi.GetAccessTokenFromServer(_appId,_appSecret);//超过有效期，需重新获取
                xml.SelectSingleNode("xml").SelectSingleNode("Access_Token").InnerText = mode.access_token;
                _youxrq = _youxrq.AddSeconds(int.Parse(mode.expires_in));
                xml.SelectSingleNode("xml").SelectSingleNode("Access_endTime").InnerText = _youxrq.ToString();
                xml.Save(filepath);
                Token = mode.access_token;
            }
            return Token;
        }

      
        #endregion

        public  string GetUserInfo(string openid)
        {
            var access_token = GetAccessToken();
            var jsonStr = WeChatApi.GetUserInfo(access_token, openid);
            return jsonStr;
        }
    }
}
