using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManage
{
    public class CacheHelper
    {
        private static Dictionary<string, object> customerDictionary = new Dictionary<string, object>();

        public static void Add(string key,object oValue)
        {
            customerDictionary.Add(key, oValue);
        }
        public static object Get(string key)
        {
            return customerDictionary[key];
        }

        public static bool isExists(string key)
        {
            if (customerDictionary.ContainsKey(key))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static void Remove(string key)
        {
            customerDictionary.Remove(key);
        }

        public static void RemoveAll()
        {
            customerDictionary.Clear();
        }

        public static void RemoveContains(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            foreach (var item in customerDictionary)
            {
                if (func.Invoke(item.Key))
                {
                    keyList.Add(item.Key);
                }
            }
            keyList.ForEach(d => customerDictionary.Remove(d));
        }
    }
}
