using Abp.Net.Sms;
using LitJson;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeChatPay;

namespace Asp.CoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 暂时注释
                //Console.WriteLine("Hello World!");

                //{
                //    var stratec = new Company
                //    {
                //        Name = "Stratec",
                //        Website = "wwww.stratec.com",
                //        HeadOfficeAddress = "Birkenfeld",
                //    };

                //    var firstEmployee = new Employee
                //    {
                //        Name = "Bassam Alugili",
                //        Age = 42,
                //        Company = stratec
                //    };

                //    var microsoft = new Company
                //    {
                //        Name = "Microsoft",
                //        Website = "www.microsoft.com",
                //        HeadOfficeAddress = "Redmond, Washington",
                //    };

                //    var secondEmployee = new Employee
                //    {
                //        Name = "Satya Nadella",
                //        Age = 52,
                //        Company = microsoft
                //    };

                //    DumpEmployee(firstEmployee);
                //    DumpEmployee(secondEmployee);
                //} 
                #endregion

                #region  微信支付
                #region 统一下单
                // WeChatPayAPI payAPI = new WeChatPayAPI();
                //var data=  payAPI.GetUnifiedOrderResult(2, "");

                //TimeSpan timeSpan = DateTime.Now.AddMinutes(26)- DateTime.Now;
                //Console.WriteLine (Convert.ToInt32( timeSpan.TotalSeconds));
                #endregion

                #region 申请退款
                //int useTime = 19;
                //int timeNo = useTime / 60;
                //if (useTime % 60 > 15)
                //{
                //    timeNo++;
                //}
                //Console.WriteLine(timeNo);


                //ArrayList array = new ArrayList();

                //var millisecondsTimeout = 60 * 1000;

                //Task.Run(() =>
                //{
                //    while (true)
                //    {
                //        Console.WriteLine("服务启动");
                //        Thread.Sleep( 1000);
                //        Console.WriteLine("服务休眠结束");
                //    }
                //});

                //for (int i = 0; i < 50000; i++)
                //{
                //    Task.Run(() =>
                //    {
                //        while (true)
                //        {
                //            Console.WriteLine("服务启动");
                //            Console.WriteLine("Thread.CurrentProcessorId={0}", Thread.GetCurrentProcessorId());
                //            Thread.Sleep(1000);
                //            Console.WriteLine("服务休眠结束");
                //        }
                //    });
                //}
                #endregion


                #endregion


                #region 测试阿里云短信发送

                {
                    //SmsMessage smsMessage = new SmsMessage("18788552775", "SMS_135035369", "{\"name\":\"Tom\", \"code\":\"123\"}", "西域新丝路");
                    //SmsMessage smsMessage = new SmsMessage("18788552775", "SMS_157684413", "{\"phone\":\"18788552775\",\"pass\":\"123qwe\"}", "快乐陪护");

                    //SmsSenderConfiguration smsSenderConfiguration = new SmsSenderConfiguration();
                    //AliDayuSmsSender aliDayuSmsSender = new AliDayuSmsSender(smsSenderConfiguration);
                    //aliDayuSmsSender.Send(smsMessage);

                }
                #endregion


                #region 发送模板消息
               //// var customer = _customerPersonRepository.GetAll().Where(d => d.OpenId == item.OpenId).FirstOrDefault();
               // var page = "pages/home/home";
               // var template_id = "_3kdMfOSJkRwKkchC9JqiPoTc9nVWNreJ7wU5YeiEiQ";
               // var data = "{\"keyword1\": {\"value\": \"您的剩余时间还有2分钟，请记得及时关锁还床,以免超时押金被扣！\" }, \"keyword2\": { \"value\":\"50\" }, \"keyword3\": { \"value\":\"123456\" } }";
               // var result = getSendTemplateMessage("oR-EQ5aT0g3b5rUcAtGQh-jfPXVs", template_id, page, "1547120935631", data).Result;
               // //Log.Debug(" AppletTemplateMessageAppService", $"向小程序用户 {""} 发送订单到期提醒！结果为：{result} ");
               // Console.WriteLine("AppletTemplateMessageAppService   向小程序用户 {item.OpenId} 发送订单到期提醒！结果为：{result}");
                #endregion



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }



        public static void DumpEmployee(Employee employee)
        {
            switch (employee)
            {
                //case Employee { Name: "Bassam Alugili", Company: Company(_, _, _)}
                //    employeeTmp:
                //    {
                //        Console.WriteLine($"The employee:  {employeeTmp.Name}! 1");
                //    }
                //    break;

                //case Employee(_, _, ("Stratec", _, _)) employeeTmp:
                //    {
                //        Console.WriteLine($"The employee:  {employeeTmp.Name}! 2");
                //    }
                //    break;

                //case Employee(_, _, Company(_, _, _)) employeeTmp:
                //    {
                //        Console.WriteLine($"The employee:  {employeeTmp.Name}! 3");
                //    }
                //    break;

                default:
                    Console.WriteLine("Other company!");
                    break;
            }
        }
        private static async Task<string> GetAccessTokens()
        {
            string appid = "wxf67359b6c09bd007";
            string secret = "4a11115fe2dcc4f0fd175381836ef393";
            string requestUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appid}&secret={secret}";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            myRequest.Method = "GET";
            myRequest.Proxy = null;
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string res = reader.ReadToEnd();
            JsonData Datajson = JsonMapper.ToObject(res);

            return Datajson["access_token"].ToString();

        }

        private static async  Task<string> getSendTemplateMessage(string touser, string template_id, string page, string from_id, string data, string emphasis_keyword = "keyword1.DATA")
        {
            var access_token = await  GetAccessTokens();
            string templateUrl = $"https://api.weixin.qq.com/cgi-bin/message/wxopen/template/send?access_token={access_token}";

            //var postdata = "{ \"touser\": \"oR-EQ5U1_OFUqwND12cJgB5Yd6-8\",\"template_id\": \"_3kdMfOSJkRwKkchC9JqiPoTc9nVWNreJ7wU5YeiEiQ\",\"page\": \"pages/home/home\",\"form_id\": \"1547035850169\",";
            //postdata += "\"data\": {\"keyword1\": {\"value\": \"您的剩余时间还有30分钟，请记得及时关锁还床,以免超时押金被扣！\" }, \"keyword2\": { \"value\":\"50\" }, \"keyword3\": { \"value\":\"123456\" } },";
            //postdata += "\"emphasis_keyword\": \"您的剩余时间还有30分钟，请记得及时关锁还床,以免超时押金被扣\"}";
            var postdata = "{ \"touser\": \"" + touser + "\",\"template_id\": \"" + template_id + "\",\"page\": \"" + page + "\",\"form_id\": \"" + from_id + "\",";
            postdata += "\"data\":" + data + ",";
            postdata += "\"emphasis_keyword\": \"" + emphasis_keyword + "\"}";
            var res = HttpPost(templateUrl, postdata);

            return res;

        }


        private static string HttpPost(string url, string postDataStr)
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
    public class Company
    {
        public string Name
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        public string HeadOfficeAddress
        {
            get;
            set;
        }

        public void Deconstruct(out string name, out string website, out string headOfficeAddress)
        {
            name = Name;
            website = Website;
            headOfficeAddress = HeadOfficeAddress;
        }
    }

    public class Employee
    {
        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public Company Company
        {
            get;
            set;
        }

        public void Deconstruct(out string name, out int age, out Company company)
        {
            name = Name;
            age = Age;
            company = Company;
        }
    }

}
