﻿using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using WeChatPay.Model;
using WeChatPay.Service;

namespace Asp.Net.PAY.Application.WeChatPay.Service
{
    public class HttpService
    {
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        /// <summary>
        /// 处理http POST请求，返回数据
        /// </summary>
        /// <param name="xml">请求参数</param>
        /// <param name="url">请求的url地址</param>
        /// <param name="isUseCert">是否启用证书</param>
        /// <param name="timeout">请求超时时间</param>
        /// <returns></returns>
        public static string Post(string xml, string url, bool isUseCert, int timeout)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WeChatPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //是否使用证书
                if (isUseCert)
                {
                    string path = AppContext.BaseDirectory;// HttpContent.Current.Request.PhysicalApplicationPath;
                    //X509Certificate2 cert = new X509Certificate2(path + WeChatPayConfig.SSLCERT_PATH, WeChatPayConfig.SSLCERT_PASSWORD);
                    //request.ClientCertificates.Add(cert);
                    X509Certificate2 cer = new X509Certificate2(path + WeChatPayConfig.SSLCERT_PATH, WeChatPayConfig.SSLCERT_PASSWORD, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                   request.ClientCertificates.Add(cer);
                    WeChatLog.Debug("WxPayApi", "PostXml used cert");


                }

                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
               // Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
               // Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
               // Log.Error("HttpService", e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WeChatLog.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    WeChatLog.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new WeChatPayException(e.ToString());
            }
            catch (Exception e)
            {
                WeChatLog.Error("HttpService", e.ToString());
                throw new WeChatPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        public static string Get(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                //设置代理
                //WebProxy proxy = new WebProxy();
                //proxy.Address = new Uri(WeChatPayConfig.PROXY_URL);
                //request.Proxy = proxy;

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();

                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
               // Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                WeChatLog.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                WeChatLog.Error("HttpService", e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WeChatLog.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    WeChatLog.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new WeChatPayException(e.ToString());
            }
            catch (Exception e)
            {
                WeChatLog.Error("HttpService", e.ToString());
                throw new WeChatPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
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
        public static string HttpPost(string url, string postDataStr)
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
