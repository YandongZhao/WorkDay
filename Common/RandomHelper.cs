using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public  class RandomHelper
    {

        public static  string Decode(string code)
        {
            //提取用户id
            string str = "";
            string uid = "";
            for (int i = 0; i < code.Length; i += 2)
            {
                str += code.Substring(i, 1);
            }
            //剔除高位零
            for (int i = 0; i < str.Length; i++)
            {
                if (!str.Substring(i, 1).Equals("0"))
                {
                    str = str.Substring(i, str.Length - i);
                    break;
                }
            }
            uid = Convert.ToInt32(str, 16).ToString();

            return uid;
        }

        public static  string CreateCode(int len, string sourcecode, int uid)
        {
            //十进制转十六进制
            string hexid = Convert.ToString(uid, 16);

            //高位补零
            string str = "";

            for (int i = len / 2; i > hexid.Length; i--)
            {
                str += "0";
            }
            str += hexid;

            //插入随机字符

            Random ran = new Random();
            for (int i = 1; i < str.Length + 1; i += 2)
            {
                str = str.Insert(i, sourcecode.Substring(ran.Next(0, sourcecode.Length - 1), 1));
            }
            return str;
        }


        // <summary>
        /// 计算字符串中子串出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子串</param>
        /// <returns>出现的次数</returns>
        public static int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }
            return 0;
        }

    }
}
