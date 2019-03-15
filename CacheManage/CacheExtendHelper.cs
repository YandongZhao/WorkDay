using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheManage
{
    public class CacheExtendHelper
    {
        private static Dictionary<string, KeyValuePair<object, DateTime>> customerDictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();
        static CacheExtendHelper()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    List<string> keyList = new List<string>();
                    foreach (var item in customerDictionary.Keys)
                    {
                        var dateTimekey = customerDictionary[item];
                        if (dateTimekey.Value > DateTime.Now)
                        {
                        }
                        else
                        {
                            keyList.Add(item);
                        }
                    }
                    keyList.ForEach(d => customerDictionary.Remove(d));
                    Thread.Sleep(60 * 1000);
                }
            });
        }



        public static void Add(string key, object value, int second = 60)
        {
            customerDictionary.Add(key, new KeyValuePair<object, DateTime>(value
                , DateTime.Now.AddSeconds(second)));
        }
        public static T Get<T>(string key)
        {
            return (T)customerDictionary[key].Key;
        }
        /// <summary>
        /// 只要数据过期了，就一定不会被查出来
        /// 如果数据没人查询呢？ 那就常驻内存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsExist(string key)
        {
            if (customerDictionary.ContainsKey(key))
            {
                var valueTime = customerDictionary[key];
                if (valueTime.Value > DateTime.Now)//现在比过期时间大  所以没过期
                {
                    return true;
                }
                else
                {
                    customerDictionary.Remove(key);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据指定的key 来清除
        /// 一般不更新，只删除，第一次用的时候再去初始化
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            customerDictionary.Remove(key);
        }

        /// <summary>
        /// 类别数据--映射表---找出用户--拼装全部的key---看看缓存有没有，有的清除  不对
        /// 直接全部remove，简单粗暴，全部干掉
        /// </summary>
        public static void RemoveAll()
        {
            customerDictionary.Clear();
        }

        /// <summary>
        /// 按条件删除   func
        /// </summary>
        /// <param name="func"></param>
        public static void RemoveCondition(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            foreach (var item in customerDictionary.Keys)
            {
                if (func.Invoke(item))
                {
                    keyList.Add(item);
                }
            }
            keyList.ForEach(key => customerDictionary.Remove(key));
        }



        public static T GetData<T>(string key, Func<T> func)
        {
            T t = default(T);
            if (IsExist(key))
            {
                t = Get<T>(key);
            }
            else
            {
                t = func.Invoke();// DataSource.QueryByDB(num);
                Add(key, t);
            }
            return t;
        }
    }
}
