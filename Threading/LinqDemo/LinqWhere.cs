using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class LinqWhere
    {

        public static void Query()
        {
            int[] array = { 4, 7, 8, 1, 2, 3, 0, 5 };

            var result = from i in array where i > 1 select i;

            Console.WriteLine("输出大于5的数~");

            foreach (var n in result)
            {
                Console.WriteLine(n);
            }

        }

        public static void QueryLambda()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where(a => a.Length < 5).Select(a => a).OrderByDescending(a => a);
            Console.WriteLine("Short digits:");
            foreach (var d in shortDigits)
            {
                Console.WriteLine(d);
            }

            int[] intarray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = intarray.Where(res => res >= 3 && res <= 9).Select(res => res).OrderByDescending(res => res);
            Console.WriteLine("int array");
            foreach (var a in result)
            {
                Console.WriteLine(a);
            }

            int[] groupbyarray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var groupby = from a in groupbyarray group a by a % 3 into b select new { index = b.Key, value = b };
            Console.WriteLine("groupby array");
            foreach (var i in groupby)
            {
                Console.WriteLine(i.index + "    " + i.value);
                foreach (var j in i.value)
                {
                    Console.WriteLine(j);
                }
            }

            var proList = new LinqWhere().GetProList();
            var pro = from a in proList group a by a.Category into b select new {index=b.Key,value=b};
            foreach (var i in pro)
            {
                Console.WriteLine(i.index);
                foreach (var j in i.value)
                {
                    Console.WriteLine("名字："+j.Name+"\r\n类别:"+j.Category);
                }
            }
        }


        public List<Product> GetProList()
        {

            return new List<Product>() 
            { 
                new Product() { Name = "小米", Category = "手机" },
                new Product() { Name = "苹果", Category = "手机" },
                new Product() { Name = "三星", Category = "手机" },
                new Product() { Name = "changhong", Category = "电视" },
                new Product() { Name = "华为", Category = "手机" },
                new Product() { Name = "sony", Category = "电视" },
                new Product() { Name = "诺基亚", Category = "手机" },
                new Product() { Name = "panda", Category = "电视" },
                new Product() { Name = "中兴", Category = "手机" }
            };
        }

    }

    public class Product
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
