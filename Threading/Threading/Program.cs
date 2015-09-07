using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Main threadId is:" + Thread.CurrentThread.ManagedThreadId);
            //Message message = new Message();
            //Thread thread = new Thread(new ThreadStart(message.ShowMessage));
            //thread.Start();
            //Console.WriteLine("Do something ..........!");
            //Console.WriteLine("Main thread working is complete!");

            Message msg = new Message();
            var del = new SumDel(msg.Sum);
            Console.WriteLine("begin");
            IAsyncResult result = del.BeginInvoke(5, 6, null, null);
            Console.WriteLine("end");
            var str = del.EndInvoke(result);
            Console.WriteLine("结果："+str);
            Console.Read();

        }
    }

    public class Message
    {
        public void ShowMessage()
        {
            string message = string.Format("当前线程是：{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(3000);
                Console.WriteLine("当前个数是：" + i);
            }
        }

        public string Sum(int x, int y)
        {
            Console.WriteLine("开始执行sum方法");
            Thread.Sleep(1000);
            Console.WriteLine(x+y);
            return (x + y).ToString();
        }

    }

    public delegate string SumDel(int x, int y);
}
