using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = LoadFromXml(@"F:\学习\Threading\XmlDemo\TreeView.xml", typeof(Screen));

            Console.WriteLine("读取成功！");
            Console.Read();
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Screen));
                    result = (Screen)xmlSerializer.Deserialize(fs);
                }
            }
            return result;
        }
    }
}
