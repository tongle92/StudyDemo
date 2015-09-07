using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo
{
    /// <summary>
    /// 没有参数与返回值
    /// </summary>
    class Program
    {
        //委托方法开启多线程  定义委托
        public delegate int myDel(int param);
        static void Main(string[] args)
        {
            #region 1、2种情况
            //for (int i = 0; i < 20; i++)
            //{
            //    #region 无参无返回值
            //    //ThreadStart start = new ThreadStart(Calculate);
            //    //Thread thread = new Thread(start);
            //    ////开始执行
            //    //thread.Start();
            //    #endregion

            //    #region 单个参数
            //    //ParameterizedThreadStart start = new ParameterizedThreadStart(Calculate);
            //    //Thread thread = new Thread(start);
            //    //thread.Start(i * 10 + 10);
            //    #endregion

               
            //}
            //Thread.Sleep(1000);
            //Console.WriteLine("当前休眠了1000");
            //Console.Read();
            #endregion

            #region 专门线程类
            //MyThread myThread = new MyThread(8);
            //ThreadStart start = new ThreadStart(myThread.Calculate);
            //Thread thread = new Thread(start);
            //thread.Start();

            //while (thread.ThreadState != ThreadState.Stopped)
            //{
            //    Thread.Sleep(10);
            //    Console.WriteLine("当前休眠了10");
            //}
            ////打印结果
            //Console.WriteLine(myThread.result);
            //Console.Read();
            #endregion

            #region 使用匿名方法开启多线程
            ////作为参数
            //int param = 10;
            ////作为返回值
            //int result = 100;

            //ThreadStart start = new ThreadStart(delegate()
            //{
            //    Random random = new Random();
            //    Thread.Sleep(random.Next(100,1000));
            //    Console.WriteLine("休眠了"+random.Next(100,1000));
            //    Console.WriteLine("参数为："+param);
            //    result = param * 10;
            //});

            //Thread thread = new Thread(start);
            //thread.Start();

            //while (thread.ThreadState != ThreadState.Stopped)
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("休眠了" + 1000);
            //}

            //Console.WriteLine("结果为"+result);
            //Console.Read();
            #endregion 

            #region 使用委托的方法开启多线程 用委托(Delegate)的BeginInvoke和EndInvoke方法操作线程
            //myDel del = Calculate;
            //IAsyncResult result = del.BeginInvoke(8888, null, null);
            ////阻塞enduinvoke方法8888秒
            //int res = del.EndInvoke(result);
            //Console.WriteLine("结果为" + res);
            //Console.Read();
            #endregion

            #region 使用IAsyncResult.IsCompleted属性来判断异步调用是否完成
            //myDel del = Calculate;
            //IAsyncResult result = del.BeginInvoke(8888, null, null);
            //while (!result.IsCompleted)
            //{
            //    Console.WriteLine("***");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("休眠了"+1000);
            //}

            //int res = del.EndInvoke(result);
            //Console.WriteLine("结果为："+res);
            //Console.Read();
            #endregion

            #region 使用waitone方法 WaitOne的第一个参数表示要等待的毫秒数，在指定时间之内，WaitOne方法将一直等待，直到异步调用完成，并发出通知，WaitOne方法才返回true。当等待指定时间之后，异步调用仍未完成，WaitOne方法返回false，如果指定时间为0，表示不等待，如果为-1，表示永远等待，直到异步调用完成。
            //myDel del = Calculate;
            //IAsyncResult result = del.BeginInvoke(2000, null, null);
            //while (!result.AsyncWaitHandle.WaitOne(1000))
            //{
            //    Console.WriteLine("等待了1000");
            //}
            //int res = del.EndInvoke(result);
            //Console.WriteLine("结果为"+res);
            //Console.Read();
            #endregion

        }

        //定义静态方法
        public static int Calculate(int param)
        {
            Console.WriteLine("任务开始!");
            Thread.Sleep(param);
            Console.WriteLine("休眠了"+param);
            Random random = new Random();
            int n = random.Next(100, 1000);
            Console.WriteLine("任务完成");
            return n;
        }
        public static void Calculate()
        {
            DateTime time = DateTime.Now;
            Random random = new Random();
            Thread.Sleep(random.Next(100, 1000));
            Console.WriteLine("当前时间：" + time.ToString("yyyy-MM-dd HH:mm:ss ")+time.Millisecond);
        }


        public static void Calculate(object obj)
        {
            Random random = new Random();
            Thread.Sleep(random.Next(100, 1000));
            Console.WriteLine(obj);
        }
    }

    /// <summary>
    /// 专门线程类
    /// </summary>
    public class MyThread
    {
        //参数
        public int param { get; set; }
        //返回值
        public int result { get; set; }

        //构造函数
        public MyThread(int param)
        {
            this.param = param;
        }
   
        //线程执行方法
        public void Calculate() 
        {
           //随机数对象
            Random random = new Random();
            //随机休眠一段时间
            Thread.Sleep(random.Next(100, 1000));
            Console.WriteLine("当前休眠了" + random.Next(100, 1000));
            Console.WriteLine("当前参数："+this.param);
            result = this.param * 10;

        }
    }
}
