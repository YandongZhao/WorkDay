using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Comm
{
    public class PhoneHelper
    {

        #region 查询手机归属地
        public static string getphones(string phone, int id)
        {
            Uri NewUrl = new Uri("http://www.baidu.com/s?wd=" + phone.Trim());
            string phc = "";
            try
            {
                HttpWebRequest HWR = WebRequest.Create(NewUrl) as HttpWebRequest;

                HttpWebResponse HWRP = HWR.GetResponse() as HttpWebResponse;

                StreamReader sr = new StreamReader(HWRP.GetResponseStream(), System.Text.Encoding.UTF8);

                string html = sr.ReadToEnd();

                Regex rg = new Regex(@"<span>([^<]*)&nbsp;([^<]*)&nbsp;&nbsp;[^<]*</span>");

                Match m = rg.Match(html);

                GroupCollection gc = m.Groups;

                string shenn = gc[1].ToString();
                string fenn = gc[2].ToString();
                #region 查询省份
                //string sql = "select cr_name from fd_region where cr_name like '%" + shenn + "%' and cr_parent_id=@id";
                //SqlHelper sqlHelper = new SqlHelper();
                //SqlParameter para = new SqlParameter("@id", SqlDbType.Int);
                //para.Value = 1;
                //DataTable shen2 = sqlHelper.ExecuteDataTable(sql, para);
                ////var shen2 = fd_region.GetByFilter("cr_name like '%" + shenn + "%' and cr_parent_id = 1 ");
                ////if (shenn.Trim() == "")
                ////{
                ////    shen2 = fd_region.GetByFilter("cr_name like '%" + fenn + "%' and cr_parent_id = 1 ");
                ////}


                //if (shen2.Rows.Count > 0)
                //{
                //    string sql2 = "select * from fd_region where cr_name like '%" + fenn + "%'";
                //    //var fdregion = fd_region.GetByFilter("  cr_name like '%" + fenn + "%' ");
                //    SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                //    param.Value = 1;
                //    DataTable fdregion = sqlHelper.ExecuteDataTable(sql2, param);

                //    string provi = fdregion.Rows[0]["cr_name"].ToString();
                //    if (provi == "中国")
                //        phc = "城市," + "城市";
                //    else
                //        phc = provi + "," + fdregion.Rows[0]["cr_id"].ToString();

                //    string sql3 = "update fd_appointment set provice='" + shen2.Rows[0]["cr_name"] + "',city='" + phc.Split(',')[0] + "'where id=@id";
                //    SqlParameter param2 = new SqlParameter("@id", SqlDbType.Int);
                //    param2.Value = id;
                //    var result = sqlHelper.ExecuteNonQuery(sql3, param2);
                    //var k = fd_appointment.Update(id, new fd_appointment_update() { provice = shen2[0].cr_name, city = phc.Split(',')[0] });
               // }


                #endregion
                sr.Close();
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

    }
}
