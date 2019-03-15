using Comm;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WeChatComm;
//using WeChatComm;

namespace Asp.NetApp
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                #region 关于短信发送
                {
                    //string templete = "测试短信";
                    //string phone = "18788552775";
                    ////发送预约成功短息
                    //SendMassage massage = new SendMassage("http://smssh1.253.com/msg/send/json", "N3741447", "w5QmCunylt42fa");
                    //string result = massage.Send(phone, templete);
                }



                //{
                //    string phone = "18788552775";
                //    string templete = "您已成功预约上海皮肤科专家，由于专家号稀缺，稍后工作人员将给您回电确认患者信息，请注意接听来电！";
                //    //发送预约成功短息
                //    SendMassage massage = new SendMassage("N4264367", "h5Hi6lp1m");
                //    string result = massage.Send(phone, templete);
                //}


                {
                    //string phone = "18788552775";
                    //string templete = "（{0}）您已成功预约{1}上海中大肿瘤医院{2}专家号，预约编号:{3} 。请于{4}凭预约编号至一楼大厅预检台取号就诊。患者较多请提前安排好行程，按时到院就诊。如来院路线不清楚可致电：400-6622-299 、021-35353558  院址:上海市虹口区场中路685弄8号(场中路与凉城路铁路交汇处）";
                    ////发送预约成功短息
                    //SendMassage massage = new SendMassage("http://smssh1.253.com/msg/send/json", "N4931669", "345dgjTxk");
                    //string result = massage.Send(phone, templete);
                    //Console.WriteLine(result);
                }

                // DateTime dateTime = DateTime.Now;
                {
                    //string info = "测试数据发送！";

                    //var sms = new
                    //{
                    //    info,
                    //    appID = 17013461,
                    //    u = "085332003235855934"
                    //};

                    //SendHelper sendHelper = new SendHelper("http://wd.120fd.com/Ding/sms");
                    //var postData = JsonConvert.SerializeObject(sms);
                    //var postData2 = JsonConvert.SerializeObject(sms);
                    //var result = sendHelper.HttpPost(postData);
                    //var result2 = sendHelper.HttpPost(postData2);
                    //Console.WriteLine(result);
                    //Console.WriteLine(result2);

                }
               
                //string strValue = "https://m.baidu.com/baidu.php?sc.0s0000KlmKuCTsdU2HA0dhOiQO6S7YUB6LjdjSMDnRZV0LGrJrkib_uhvWKbOHBimbd3YD2stjB6TIfvjqy5K1NTluf50YOCfGaLZwV4QBe9UDixmJNnFC2F-3G9F7rasNBBcezt4QufuPxMB6Z59sP4d3ZG_VtRr42c3VPnEra2XdLTp0.7Y_iTIg-sYISOzIPJ6CLYmrqerQKjW91tIyx9CeqSxqxoSE5SOgMCLYTOjwLeOSkOv591Oz5d4SzEW3oDseZZgug__oePps1f_TILWvIB6.U1Yk0ZDqsIzs1T88dVxDkQWvYoLR8ooj0ZGsUWYYnj0VPWmznBYzrHb0TA-W5H00IjLKLQjPzleydtHD85UiEIil8_n0pyYqnWcz0ATqIvNsT100Iybq0ZKGujYz0APGujYYnHD0UgfqnH0kPdtznjmzg16dPjNxn1msnNtznjRk0AVG5H00TMfqP1b10ANGujYknWcLPW7xnH0zPHmLg1Dzn1nvndtknHTsn19xnHc1nWbzg1DznjD3ndtknH63rHKxnHD3rjmkg1Dkrj6YP7tknH63n1wxnHD3P1b4g1DznjRdn7tknjT1nHPxnHczrjm1g1DkP1n1n7tknHTYn1n0mhbqnW0vg1fsn-tznj0sn-tznj0vnsKVm1YLn1f3Pjb3PHuxrHckPHckPH64g1nsPHm3PWTsrjwxn7tLnHTvPHcv0Z7spyfqn0Kkmv-b5H00ThIYmyTqn0K9mWYsg100ugFM5H00TZ0qn0K8IM0qna3snj0snj0sn0KVIZ0qn0KbuAqs5HD0ThCqnfKbugmqIv-1ufKhIjYz0ZKC5H00ULnqn6KBI1YY0A4Y5HD0TLCqn1csg1DsnjD0IZN15HRYrHDkPH0YP1cLrjnzn1b1nWc0ThNkIjYkPHcYPHT3nW6LrjTs0ZPGujYLuyw-mhcLujb3mHfdrym10AP1UHYvwWRdfHbzfRfsP1R1nWND0A7W5HD0TA3qn0KkUgfqn0KkUgnqn0KlIjYs0AdWgvuzUvYqn7tsg1Kxn7ts0Aw9UMNBuNqsUA78pyw15HKxn7tsg1Kxn0Ksmgwxuhk9u1Ys0AwWpyfqn0K-IA-b5iYk0A71TAPW5H00IgKGUhPW5H00Tydh5HDv0AuWIgfqn0KhXh6qn0Khmgfqn0KlTAkdT1Ys0A7buhk9u1Yk0Akhm1Ys0ZIhThqV5HDsnH6snHwh0Z91IZRqP1DLPWRzP6KWThnqPH6znHb";

                #endregion

                #region 建周短信发送
                {
                        //Encoding myEncoding = Encoding.GetEncoding("utf-8");
                        //string param = HttpUtility.UrlEncode("account", myEncoding) +
                        //"=" + HttpUtility.UrlEncode("jz004", myEncoding) +
                        //"&" + HttpUtility.UrlEncode("password", myEncoding) +
                        //"=" + HttpUtility.UrlEncode("xxxxx", myEncoding) +
                        //"&" + HttpUtility.UrlEncode("destmobile", myEncoding) +
                        //"=" + HttpUtility.UrlEncode("18717830363", myEncoding) +
                        //"&" + HttpUtility.UrlEncode("msgText", myEncoding) +
                        //"=" + HttpUtility.UrlEncode("c#的问候c#的问候【建周科技】", myEncoding) +
                        //"&" + HttpUtility.UrlEncode("sendDateTime", myEncoding) +
                        //"=" + HttpUtility.UrlEncode("", myEncoding);

                        //byte[] postBytes = Encoding.ASCII.GetBytes(param);

                        //HttpWebRequest req = (HttpWebRequest)
                        //HttpWebRequest.Create("http://www.jianzhou.sh.cn/JianzhouSMSWSServer/http/sendBatchMessage");
                        //req.Method = "POST";
                        //req.ContentType =
                        //"application/x-www-form-urlencoded;charset=utf-8";
                        //req.ContentLength = postBytes.Length;
                        //var result = req.GetRequestStream();

                        //using (Stream reqStream = req.GetRequestStream())
                        //{
                        //    reqStream.Write(postBytes, 0, postBytes.Length);
                        //}
                        
                  
                }
                #endregion

                #region 关于时间的一些计算
                {

                    //DateTime date = DateTime.Now;
                    //ArrayList arrayList = new ArrayList();
                    //for (int i = 0; i < 7; i++)
                    //{
                    //    int k = i - 3;
                    //    arrayList.Add(date.AddDays(k).ToShortDateString());
                    //}

                    //string nowWeek = DateTime.Now.ToString();

                    ///获取最近7天的日期
                    //string sValue = "";
                    //for (int i = 0; i < 7; i++)
                    //{
                    //    string date = DateTime.Now.AddDays(i).ToString("MM月dd日");
                    //    sValue += date + ",";
                    //}
                    //Console.WriteLine(sValue.TrimEnd(','));


                    //DateTime dt = DateTime.Now;  //当前时间  

                    //DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一  
                    //DateTime endWeek = startWeek.AddDays(6);  //本周周日  

                    //DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初  
                    //DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末  
                    //                                                          //DateTime endMonth = startMonth.AddDays((dt.AddMonths(1) - dt).Days - 1);  //本月月末  

                    //DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初  
                    //DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末  

                    //DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初  
                    //DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末 


                    //string strdate = DateTime.Now.ToString("yyyy-MM-dd [HH:mm]");
                    //Console.Write(strdate);
                    //DateTime date = Convert.ToDateTime(strdate);
                    //Console.WriteLine(date);
                }




                #region 获取指定日期的星期
                //string[] weekDays = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                //DateTime date = DateTime.Now;
                //string week = weekDays[(int)date.DayOfWeek];

                // Console.WriteLine(week);
                #endregion
                #endregion

                #region 微信获取一些东西demo

                {
                    ////string appId = "wx844f5ba6b4467f8b";
                    ////string appSecret = "dafa79f92664b10da7c6f21b796f1d5c";
                    //string appId = "wx1fb9a48e5072cabc";
                    //string appSecret = "b4fbee41c0fd4650883e2a9a111d38db";
                    //WxRequestHelper helper = new WxRequestHelper(appId, appSecret);
                    //// string openId = "oi2QJuPG60OpuTjWN7nGuvvY5hW0";
                    //string openId = "o5JGbjj1YQoB6aGXRNJaWAXwmk-c";
                    //helper.GetAccessToken();
                    //string jsonStr = helper.GetUserInfo(openId);
                    //userinfo userinfo = JsonHelper.ParseFromJson<userinfo>(jsonStr);
                    //Console.WriteLine(userinfo.nickname);
                }
                #endregion

                #region 测试字符串的替换
                {
                    //string str = "{name} 上的VS  {result.orderTime}第三次VS的{result.id}但是VCD是{expertname}萨阿丹发生的";

                    //str = str.Replace("{name}", "赵艳东").Replace("{result.orderTime}", DateTime.Now.ToShortDateString()).Replace("{result.id}", "4567890").Replace("{expertname}", "刘教授");

                    //Console.WriteLine(str);
                } 
                #endregion


                #region 生成二维码
                {
                    //QRCodeHelper.GetQrcode();
                }

                {
                    //string filePath = Path.Combine("F:/Readme/WebApplication1/Asp.NetApp/QrcodeImage/");   
                    //if (Directory.Exists(filePath))
                    //    if (Directory.Exists(filePath))
                    //{
                    //    Directory.CreateDirectory(filePath);
                    //}
                    //var result= QRCodeHelper.Create("http://www.kuiyu.net/", 4, filePath);
                }
                {
                    //QRCodeHandler qr = new QRCodeHandler();
                    //string path = "F:/Readme/WebApplication1/Asp.NetApp/QrcodeImage/";    //文件目录  
                    //string qrString = "http://blog.csdn.net/pan_junbiao";                         //二维码字符串  
                    //string logoFilePath = path + "myLogo.jpg";                                    //Logo路径50*50  
                    //string filePath = Path.Combine(path + Guid.NewGuid() + ".jpg");                                        //二维码文件名  
                    //if (Directory.Exists(filePath))
                    //{
                    //    Directory.CreateDirectory(filePath);
                    //}

                    //var result = QRCodeHelper.CreateQRCode(qrString, "Byte", 5, 0, "H", filePath, true, logoFilePath);   //生成  

                    //Console.WriteLine(result);
                }
                #endregion

                #region 生成随机6位邀请码
                {
                   // int len = 6;    //code偶数位

                   // //自定义乱序字符串,‘0-9 A-Z’,剔除易混淆字符‘I，O’，剔除高位补‘0’
                   //  string sourcecode = "ABC0DEF1GHI2JKL3MNO4PQR5STU6VWX7YZ89";
                   //// string sourcecode = "0123456789";
                   //// int uid = 1;      //用户id

                   
                   // List<string> list = new List<string>();
                   // for (int i = 0; i < 1000000; i++)
                   // {
                   //     int uid = i;
                   //     string code = RandomHelper.CreateCode(len, sourcecode, uid);
                   //     string decode = RandomHelper.Decode(code);
                   //     list.Add(code);
                   // }

                   // string stringList = string.Join(",", list.ToArray());

                   // Console.WriteLine(stringList);
                   // foreach (var item in list)
                   // {
                   //     int boolTrue = RandomHelper.SubstringCount(item, stringList);

                   //     if (boolTrue>0)
                   //     {
                   //         Console.WriteLine($"重复出现的字符串{item},重复出现{boolTrue}次");
                   //     }
                   //     else
                   //     {
                   //         Console.WriteLine("没有重复数据!");
                   //     }
                     
                   // }

                   // Console.WriteLine();


                   // Console.WriteLine(decode);
                }
                #endregion

                #region 长链接转短链接
                {
                    //string longUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx844f5ba6b4467f8b&redirect_uri=http://pub.zhongda021.com/Qrcodetest/UserAuth.aspx&response_type=code&scope=snsapi_base#wechat_redirect";
                    //////string shortUrl = UrlHelper.LongToShortUrl(longUrl);

                    //string url = "http://api.c7.gg/api.php?url=urlencode("+ longUrl + ")";
                    ////string shortUrl=HttpHelper.HttpGet(url);
                    //string shortUrl = HttpHelper.HttpPost(url, "");
                    //Console.WriteLine(shortUrl);

                    //QRCodeHelper.GetQrcode(shortUrl);
                } 
                #endregion

                {
                    //DataSet dataSet = new DataSet();
                    //DataTable dataTable = new DataTable();
                    ////dataTable.Rows[0]
                    //string value = dataTable.Rows[0][0].ToString();
                    //Console.WriteLine(value);
                    ////Console.WriteLine("字符串长度为：" + strValue.Length);
                }

                {
                    //钉钉 ding接口测试

                }
                #region 回写手机归属地
                {
                    //SqlHelper sqlHelper = new SqlHelper();
                    //string sql = "select * from fd_appointment where status = 0  and isdelete=0  and createTime >= '2017-01-01' and createTime <'2017-07-01'and provice is null and sectionId =@deptId  order by createTime desc";

                    //SqlParameter para = new SqlParameter("@deptId", SqlDbType.Int);
                    //para.Value = 37;
                    //DataTable dataTable = sqlHelper.ExecuteDataTable(sql, para);
                    //Console.WriteLine($"总数据有{dataTable.Rows.Count}条");
                    //for (int i = 0; i < dataTable.Rows.Count; i++)
                    //{
                    //    int id =Convert.ToInt32( dataTable.Rows[i]["id"]);
                    //    string tel = dataTable.Rows[i]["tel"].ToString();
                    //    string provice = dataTable.Rows[i]["provice"].ToString();
                    //    if (string.IsNullOrEmpty(provice))
                    //    {
                    //       getphones(tel, id);
                    //    }
                    //    string city = dataTable.Rows[i]["city"].ToString();
                    //}
                    //Console.WriteLine("循环结束");
                }
                #endregion

                #region 获取tree树数据节点
                {
                    //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ToString();
                    ////首选获取所有部门及部门的下级部门
                    //string strSql = "select depID deptId,dName deptName,parentid from dbo.department";
                    //SqlHelper sqlHelper = new SqlHelper(connStr);

                    //DataTable deptTable = sqlHelper.ExecuteDataTable(strSql, null);
                    //List<Dept> depts = new List<Dept>();
                    //for (int i = 0; i < deptTable.Rows.Count; i++)
                    //{
                    //    depts.Add(new Dept()
                    //    {
                    //        deptId = Convert.ToInt32(deptTable.Rows[i]["deptId"]),
                    //        parentId = Convert.ToInt32(deptTable.Rows[i]["parentid"]),
                    //        deptName = deptTable.Rows[i]["deptName"].ToString()
                    //    });
                    //}
                    ////查出这些部门的领导人
                    //string sql = @"select users.Duserid,users.uName,departUser.depid 
                    //               from Users,UserRole,Roles,departUser 
                    //              where Users.Id=UserRole.UserId and UserRole.RoleId=Roles.Id and departUser.duers=Users.Duserid
                    //             and exists(select 1 from dUser where dUser.userid=Users.Duserid)
                    //              and Roles.Name='approval'";
                    //DataTable userTable = sqlHelper.ExecuteDataTable(sql, null);
                    //List<User> users = new List<User>();
                    //for (int i = 0; i < userTable.Rows.Count; i++)
                    //{
                    //    users.Add(new User()
                    //    {
                    //        deptId = Convert.ToInt32(userTable.Rows[i]["depid"]),
                    //        UserId = userTable.Rows[i]["Duserid"].ToString(),
                    //        UserName = userTable.Rows[i]["uName"].ToString()
                    //    });
                    //}
                    //// 添加节点
                    //TreeNode treeNode = new TreeNode()
                    //{
                    //    state = new StateForTreeNode()
                    //    {
                    //        opened = true
                    //    },
                    //    text = depts.Where(d => d.deptId == 1).FirstOrDefault().deptName,
                    //    icon = "glyphicon glyphicon-file",
                    //    children = getChildren(1, depts, users)

                    //};

                    //string result = JsonHelper.getJsontoObject(treeNode);

                }
                #endregion

                #region 快递单号查询接口

                #endregion
                #region 微信公众号模板消息发送
                {


                    
                }
                #endregion

                {
                    //User olduser = new User()
                    //{
                    //    deptId = 12,
                    //    UserId = "xxo0",
                    //    UserName = "测试"
                    //};
                    //User newuser = new User()
                    //{
                    //    deptId = 13,
                    //    UserId = "xxo0",
                    //    UserName = "测试2"
                    //};

                    //TransReflection(newuser, olduser);
                }


                // "userNameOrEmailAddress="13122086511","password="123123","wechatToken="o8-2A4rEgQ8uaruDSSzCqAhXEbNM"

                {
                    //var data = new
                    //{
                    //    password = "123qwe",
                    //    userNameOrEmailAddress = "15837712566",
                    //    wechatToken = "o8-2A4rEgQ8uaruDSSzCqAhXEbNM"
                    //};
                    //string url = "http://localhost:62114/api/TokenAuth/LoginEasyToUseProgram";
                    //string postdata = JsonConvert.SerializeObject(data);
                    //var result = HttpHelper.HttpPost(url, postdata);

                    //Console.WriteLine(result);
                }
                {
                    var data = new
                    {
                        openid = "om50v5dgeFy3rV7GHA9T241IEzU0",
                        bleCode = 0,
                        body = "测试",
                        attach = "string",
                        total_fee = 1,
                        spend_fee = 1,
                        seizure = 0,
                        appId = "wx6868024fdc77b281"
                    };
                    string url = "http://localhost:62114/api/services/app/WeChatPayment/WeChatMemberUnifedOrder";
                    string postdata = JsonConvert.SerializeObject(data);
                    var result = HttpHelper.HttpPost(url, postdata);

                    Console.WriteLine(result);
                }

                    {

                        //var data = new
                        //{
                        //    user = new
                        //    {
                        //        Name = "测试",
                        //        Surname = "测试",
                        //        EmailAddress = "12345678@qq.com",
                        //        PhoneNumber = "15308745245",
                        //        UserName = "15308745245",
                        //        SetRandomPassword = "true",
                        //        Password = "123456",
                        //        PasswordRepeat = "123456",
                        //        IsActive = "true"
                        //    },
                        //    assignedRoleNames = new string[1] { "04a90179b1484254818989dce966763b" },
                        //    SetRandomPassword = "true",

                        //};


                        //var data = new
                        //{
                        //    password = "123qwe",
                        //    telNumber = "15837712566",
                        //    wechatToken = "ocyo10SsBYucdHHVLZYuDlC1m0nA"
                        //};

                        //var data = new
                        //{
                        //    consignee = "发光时代",
                        //    phone = "15037525309",
                        //    chelsea = "北京市,北京市,东城区",
                        //    detailedAddress = "的双方各得",
                        //    isDefault = "1"
                        //};

                        //string url = "http://localhost:62114/api/services/app/Address/Create";
                        //string postdata = JsonConvert.SerializeObject(data);
                        //var result = HttpHelper.HttpPost(url, postdata);

                        //Console.WriteLine(result);
                    }

                {
                    //var dateTime = new DateTime(2019, 2, 21);
                    //var result = getWeekforTodayToWeekStrat(dateTime);
                    //Console.WriteLine(result);

                    //var s = WeekOfMonth(dateTime, 1);
                    //Console.WriteLine(s);
                }
            


              

                //var data = new
                //        {
                //            companyId = 64,
                //            password = "2426db461fe54400",
                //            userNameOrEmailAddress = "15837712566",
                //            wechatToken = "ocyo10SsBYucdHHVLZYuDlC1m0nA"
                //        };
                //        string url = "http://localhost:62114/api/TokenAuth/AuthenticateByWechatTokenTwo";
                //        string postdata = JsonConvert.SerializeObject(data);
                //        var result = HttpHelper.HttpPost(url, postdata);
                //        Console.WriteLine(result);
                //    }

                
                #region 测试post提交

                {
                    //var data = new
                    //{
                    //    customersName = "王小二",
                    //    mobile = "18788532130",
                    //    companyAddress = "上海是",
                    //    companyMobile = "02165423120",
                    //    businessBank = "华夏银行",
                    //    bankCode = "",
                    //    dutyParagraph = "",
                    //    invoiceTitle = "",
                    //    companyId = 64,
                    //    userId = 0,
                    //    companyName = "微软",
                    //    sex = 1,
                    //    jobPosition = "",
                    //    customerLevelId = 0,
                    //    distributionCode = "",
                    //    invitingCode = ""

                    //};


                    //var data = new
                    //{
                    //    user = new
                    //    {
                    //        code = "",
                    //        name = "张三",
                    //        abbreviation = "",
                    //        industryChainCode = "",
                    //        organizationUnitId = 0,
                    //        parkMaster = new
                    //        {
                    //            code = "",
                    //            abbreviation = "",
                    //            name = "",
                    //            organizationUnitId = 0,
                    //            parkType = 0,
                    //            parkGroup = 0,
                    //            logoPath = "",
                    //            parkArea = "",
                    //            address = "",
                    //            location = "",
                    //            locationX = 0,
                    //            locationY = 0,
                    //            webSite = "",
                    //            email = "",
                    //            phone = "",
                    //            zipCode = "",
                    //            wechatPath = "",
                    //            string01 = "",
                    //            string02 = "",
                    //            string03 = "",
                    //            string04 = "",
                    //            string05 = "",
                    //            string06 = "",
                    //            appId = "",
                    //            accessKey = "string",
                    //            creationTime = "2018-10-30T02:22:50.583Z",
                    //            creatorUserId = 0,
                    //            lastModifierUserId = 0,
                    //            lastModificationTime = "2018-10-30T02:22:50.583Z",
                    //            deleterUserId = 0,
                    //            deletionTime = "2018-10-30T02:22:50.583Z",
                    //            isDeleted = true,
                    //            tenantId = 0,
                    //            extensionData = "",
                    //            id = 4
                    //        },
                    //        parkMasterId = 4,
                    //        companyType = 0,
                    //        legalPerson = "",
                    //        businessIndustry = 0,
                    //        logoPath = "",
                    //        registerCapital = 0,
                    //        registerDate = "2018-10-30T02:22:50.583Z",
                    //        businessScope = "",
                    //        parkArea = "",
                    //        address = "",
                    //        location = "",
                    //        locationX = 0,
                    //        locationY = 0,
                    //        webSite = "",
                    //        email = "",
                    //        phone = "",
                    //        businessLicense = "",
                    //        wechatPath = "",
                    //        wechatPath1 = "",
                    //        appId = "",
                    //        accessKey = "",
                    //        creationTime = "2018-10-30T02:22:50.583Z",
                    //        creatorUserId = 0,
                    //        lastModifierUserId = 0,
                    //        lastModificationTime = "2018-10-30T02:22:50.583Z",
                    //        deleterUserId = 0,
                    //        deletionTime = "2018-10-30T02:22:50.583Z",
                    //        isDeleted = true,
                    //        tenantId = 0,
                    //        extensionData = "",
                    //        id = 0
                    //    },
                    //    companyId = 64,
                    //    customer = new
                    //    {
                    //        customersName = "张三",
                    //        mobile = "18752310123",
                    //        companyAddress = "上海市",
                    //        companyMobile = "021-654123",
                    //        businessBank = "华夏银行",
                    //        bankCode = "",
                    //        dutyParagraph = "",
                    //        invoiceTitle = "",
                    //        companyId = 0,
                    //        userId = 0,
                    //        companyName = "",
                    //        sex = 0,
                    //        jobPosition = "",
                    //        creationTime = "2018-10-30T02:22:50.583Z",
                    //        creatorUserId = 0,
                    //        lastModifierUserId = 0,
                    //        lastModificationTime = "2018-10-30T02:22:50.583Z",
                    //        deleterUserId = 0,
                    //        deletionTime = "2018-10-30T02:22:50.583Z",
                    //        isDeleted = true,
                    //        tenantId = 0,
                    //        extensionData = "",
                    //        id = 0
                    //    },
                    //    customerId = 0,
                    //    customerType = 0,
                    //    customerLevelId = 0,
                    //    distributionCode = "",
                    //    invitingCode = "020A0P"
                    //};
                    //var data = new
                    //{
                    //    customersName = "李筱思",
                    //    mobile = "1806541230",
                    //    companyAddress = "江苏省",
                    //    companyMobile = "020652310",
                    //    businessBank = "",
                    //    bankCode = "",
                    //    dutyParagraph = "",
                    //    invoiceTitle = "",
                    //    companyId = 64,
                    //    userId = 48,
                    //    companyName = "黄花菜",
                    //    sex = 0,
                    //    jobPosition = "CEO",
                    //    customerLevelId = 0,
                    //    distributionCode = "",
                    //    invitingCode = "020A0P"
                    //};
                    //string url = "http://localhost:62114/api/services/app/CompanyCustomer/CreateCompanyCustomer";
                    //string postdata = JsonConvert.SerializeObject(data);
                    //var result = HttpHelper.HttpPost(url, postdata);

                    //Console.WriteLine(result);


                    //var data = new
                    //{
                    //    openid = "string",
                    //    body = "测试",
                    //    attach = "string",
                    //    total_fee = 1,
                    //    spend_fee = 0,
                    //    seizure = 0,
                    //};
                    //string url = "http://localhost:62114/api/services/app/WeChatPayment/WeChatUnifedOrder";
                    //string postdata = JsonConvert.SerializeObject(data);
                    //var result = HttpHelper.HttpPost(url, postdata);

                    //Console.WriteLine(result);
                }

                #endregion
                
                //{
                //    var data = new
                //    {
                //        Body="测试",
                //        Attach ="string",
                //        OpenId ="om50v5dgeFy3rV7GHA9T241IEzU0",
                //        BleCode ="00000010",
                //        Total_fee =40,
                //        Spend_fee =20,
                //        Seizure =20,
                //        Pay_type =0
                //    };
                //    string url = "http://localhost:62114/api/services/app/WeChatOrderMent/WeChatUnifedOrder";
                //    string postdata = JsonConvert.SerializeObject(data);
                //    var result = HttpHelper.HttpPost(url, postdata);
                //    Console.WriteLine(result);
                //}


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }


        public static  List<string> getWeekforTodayToWeekStrat(DateTime dateTime)
        {
            var result = new List<string>();
            var startTime = GetTimeStartByType("Week", dateTime).Value;
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            for (int i = 0; i < (int)dateTime.DayOfWeek; i++)
            {
                string week = Day[Convert.ToInt32(startTime.DayOfWeek.ToString("d"))].ToString();
               startTime= startTime.AddDays(1);
                result.Add(week);
            }
            return result;
        }

        public static int WeekOfMonth(DateTime day, int WeekStart)
        {
            //WeekStart                                                                      
            //1表示 周一至周日 为一周                                                        
            //2表示 周日至周六 为一周                                                        
            DateTime FirstofMonth;
            FirstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);

            int i = (int)FirstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }

            if (WeekStart == 1)
            {
                return (day.Date.Day + i - 2) / 7 + 1;
            }
            if (WeekStart == 2)
            {
                return (day.Date.Day + i - 1) / 7;

            }
            return 0;
            //错误返回值0                                                                    
        }

        private static DateTime? GetTimeStartByType(string TimeType, DateTime now)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(-(int)now.DayOfWeek + 1);
                case "Month":
                    return now.AddDays(-now.Day + 1);
                case "Season":
                    var time = now.AddMonths(0 - ((now.Month - 1) % 3));
                    return time.AddDays(-time.Day + 1);
                case "Year":
                    return now.AddDays(-now.DayOfYear + 1);
                default:
                    return null;
            }
        }

        private static bool TransReflection<TIn>(TIn tInNew, TIn tInOld)
        {
            try
            {
                var tInType = tInOld.GetType();
                foreach (var itemOut in tInOld.GetType().GetProperties())
                {
                    var pname = tInType.GetProperty(itemOut.Name);

                    if (pname != null)
                    {
                        if (pname.Name.ToLower() == "id")
                            continue;
                        itemOut.SetValue(tInOld, pname.GetValue(tInNew));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                //日志
                return false;
            }

        }

        private static List<TreeNode> getChildren(int parentId, List<Dept> depts, List<User> users)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            List<Dept> child = depts.Where(d => d.parentId == parentId).ToList();
            List<User> childuser = users.Where(d => d.deptId == parentId).ToList();
            foreach (var item in childuser)
            {
                treeNodes.Add(new TreeNode()
                {
                    state = new StateForTreeNode()
                    {
                        opened = false
                    },
                    text = item.UserName,
                    icon = "glyphicon glyphicon-user"
                });
            }

            foreach (var item in child)
            {
                treeNodes.Add(new TreeNode()
                {
                    state = new StateForTreeNode()
                    {
                        opened = false
                    },
                    text = item.deptName,
                    icon = "glyphicon glyphicon-file",
                    children = getChildren(item.deptId, depts, users)
                });
            }
            return treeNodes;
        }
        public List<MenuItem> main = new List<MenuItem>();

        public void Enter() //入口
        {
            List<MenuItem> allMenu = GetAllMenus(); //得到数据 

            main.Add(allMenu.Where(x => x.MenuID == 1).FirstOrDefault());//根节点
            AddMenu(allMenu, allMenu.Where(x => x.MenuID == 1).FirstOrDefault());//递归

            //结果树形结构
            List<MenuItem> treeMenu = main;

        }

        //父子级递归
        public void AddMenu(List<MenuItem> all, MenuItem curItem)
        {
            List<MenuItem> childItems = all.Where(ee => ee.ParentID == curItem.MenuID).ToList(); //得到子节点
            curItem.ChildItems = childItems; //将子节点加入

            //遍历子节点，进行递归，寻找子节点的子节点
            foreach (var subItem in childItems)
            {
                AddMenu(all, subItem);
            }
        }

        public List<MenuItem> GetAllMenus()
        {
            List<MenuItem> listMenuS = new List<MenuItem>();
			// 得到数据
			// 结构如下：
			//  MenuID  DisplayName  ParentID   ChildItems
			//    1        Name1        0                     根节点
			//    2        Name2        1
			//    3        Name3        1
			//    4        Name4        2
			//    5        Name5        2
			
			return listMenuS;
        }

       
    }

    public class deptAnduser
    {
        public int deptId { get; set; }
        public int parentId { get; set; }
        public int deptName { get; set; }

        public List<Dept>children {get;set;}
    }
    public class MenuItem
    {
        public int MenuID { get; set; }

        public string DisplayName { get; set; }

        public int ParentID { get; set; }

        public List<MenuItem> ChildItems { get; set; }
    }
}

