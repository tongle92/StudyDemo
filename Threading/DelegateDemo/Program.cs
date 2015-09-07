using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    //声明一个委托
    public delegate void MakeGreetingDel(string name);
    class Program
    {
        static void Main(string[] args)
        {
            #region 在方法里分别传不同的变量和方法
            //Greet greet = new Greet();
            //greet.GreetPeople("xiaoming", greet.EnglishGreet);
            //greet.GreetPeople("小明", greet.ChineseGreet);
            //Console.Read();
            #endregion

            #region 只用一个委托 绑定两个方法
            //Greet greet = new Greet();
            //MakeGreetingDel del = greet.ChineseGreet;
            //del += greet.ChineseGreet;
            //del += greet.EnglishGreet;
            //greet.GreetPeople("aa", del);

            //Console.WriteLine("减");

            //del -= greet.ChineseGreet;
            //greet.GreetPeople("bb", del);
            //Console.Read();
            #endregion

            #region 简化流程
            //Greet greet = new Greet();
            //MakeGreetingDel del = new MakeGreetingDel(greet.EnglishGreet);
            //del += greet.EnglishGreet;
            //greet.GreetPeople("aa", del);

            //Console.Read();
            #endregion

            #region del封装
            Greet greet = new Greet();
            greet.del = greet.EnglishGreet;
            greet.del += greet.ChineseGreet;
            greet.GreetPeople("aa");

            Console.Read();
            #endregion





        }

    }

    /// <summary>
    /// 问候类
    /// </summary>
    public class Greet
    {
        /// <summary>
        /// 中文问候
        /// </summary>
        /// <param name="name"></param>
        public void ChineseGreet(string name)
        {
            Console.WriteLine("早上好," + name);
        }

        /// <summary>
        /// 英文问候
        /// </summary>
        /// <param name="name"></param>
        public void EnglishGreet(string name)
        {
            Console.WriteLine("Morning," + name);
        }

        /// <summary>
        /// 问候方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="makeGreetDel"></param>
        public void GreetPeople(string name, MakeGreetingDel makeGreetDel)
        {
            makeGreetDel(name);
        }

        public  MakeGreetingDel del;

        /// <summary>
        /// 问候方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="makeGreetDel"></param>
        public void GreetPeople(string name)
        {
            if(del!=null)
                del(name);
        }
    }
}
