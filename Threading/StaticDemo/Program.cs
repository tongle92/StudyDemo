using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDemo
{

    public class Bus
    {
         static Bus()
        {
            Console.WriteLine("静态构造函数111111111");
        }

        public Bus()
        {
            Console.WriteLine("非静态构造函数2222222");
        }

        public static void Drive()
        {

            Console.WriteLine("静态方法");
        }

        public void Work()
        {
            Console.WriteLine("非静态方法");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bus.Drive();
            new Bus().Work();
            Console.ReadLine();
        }
    }
    
}
