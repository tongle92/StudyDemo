using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JsonInfo.getJsonInfo());
            Console.ReadLine();
        }
    }

    /// <summary>  
    /// 用户实体类  
    /// </summary>  
    public class UserInfo
    {
        //用户名  
        public string strName { get; set; }
        //年龄  
        public int intAge { get; set; }
        //密码  
        public string strPsd { get; set; }
        //电话号码   
        public int intTel { get; set; }
        //地址  
        public string strAddr { get; set; }
    }


    /// <summary>  
    /// 将json数据转换成实体类（方法二）  
    /// </summary>  
    public static class JsonInfo
    {
        /// <summary>  
        /// 获取将实体类转换为json数据（目的是为了更快在网页上传递数据）  
        /// </summary>  
        /// <returns></returns>  
        public static string getJsonInfo()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.strName = "张三";
            userInfo.intAge = 23;
            userInfo.strPsd = "yhx.123";
            userInfo.intTel = 2324;
            userInfo.strAddr = "北京市";
            //将对象序列化json  
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserInfo));
            //创建存储区为内存流  
            System.IO.MemoryStream ms = new MemoryStream();
            //将json字符串写入内存流中  
            serializer.WriteObject(ms, userInfo);
            System.IO.StreamReader reader = new StreamReader(ms);
            ms.Position = 0;
            string strRes = reader.ReadToEnd();
            reader.Close();
            ms.Close();
            return strRes;
        }

        /// <summary>  
        ///   
        /// </summary>  
        /// <returns></returns>  
        public static string getInfo()
        {
            string JsonStr = "[" + getJsonInfo() + "]";
            List<UserInfo> products;

            products = JsonInfo.JSONStringToList<UserInfo>(JsonStr);

            string strItem = "";
            foreach (var item in products)
            {
                strItem += item.strName + ":" + item.strPsd + ":" + item.intAge + ":" + item.intTel + ":" + item.strAddr + "<br/>";
            }
            return strItem;
        }


        /// <summary>  
        /// 返回List集合对象  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="JsonStr"></param>  
        /// <returns></returns>  
        public static List<T> JSONStringToList<T>(this string JsonStr)
        {

            JavaScriptSerializer Serializer = new JavaScriptSerializer();

            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;

        }


        ///// <summary>  
        /////   
        ///// </summary>  
        ///// <typeparam name="T"></typeparam>  
        ///// <param name="json"></param>  
        ///// <returns></returns>  
        //public static T Deserialize<T>(string json)  
        //{  

        //    T obj = Activator.CreateInstance<T>();  

        //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))  
        //    {  

        //        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());  

        //        return (T)serializer.ReadObject(ms);  

        //    }  

        //}  
    }
}

