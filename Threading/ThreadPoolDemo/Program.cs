using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //计算的个数
            const int calNum = 10;

            //每个事件被用于每个计算对象
            ManualResetEvent[] doEvents = new ManualResetEvent[calNum];
            Handle[] hArray = new Handle[calNum];
            Random r = new Random();

            //配置和使用线程池开启线程
            Console.WriteLine("开启了{0}任务",calNum);
            for(int i=0;i<calNum;i++)
            {
                doEvents[i]=new ManualResetEvent(false);
                Handle h = new Handle(i, doEvents[i]);
                hArray[i] = h;
                ThreadPool.QueueUserWorkItem(h.ThreadPoolCallback, i);
            }
            //等待所有线程池中线程计算完毕
            WaitHandle.WaitAll(doEvents);
            Console.WriteLine("所有线程计算完毕");

            //展示结果
            for (int i = 0; i < calNum; i++)
            {
                Handle h = hArray[i];
                Console.WriteLine("输入：{0}  结果：{1}",h.N,h.Cal);
            }

            Console.Read();
        }
    }

    public class Handle
    {
        //当前开始的第几个
        private int _n;
        public int N { get { return _n; } }

        //当前计算的结果
        private int _cal;
        public int Cal { get { return _cal; } }

        //通知一个或多个线程已发生的事件
        private ManualResetEvent _doneEvent;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="doneEvent"></param>
        public Handle(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        /// <summary>
        /// 计算方法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Calculate(int n)
        {
            if (n < 1)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }

        /// <summary>
        /// 线程池回调的方法
        /// </summary>
        /// <param name="threadContext"></param>
        public void ThreadPoolCallback(object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} start",threadIndex);
            _cal = Calculate(_n);
            Console.WriteLine("thread {0} result calculated", threadIndex);
            _doneEvent.Set();
        }
    }


    //public class ThreadPoolExample
    //{
    //    static void Main()
    //    {
    //        const int FibonacciCalculations = 10;

    //        // One event is used for each Fibonacci object
    //        ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
    //        Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
    //        Random r = new Random();

    //        // Configure and launch threads using ThreadPool:
    //        Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
    //        for (int i = 0; i < FibonacciCalculations; i++)
    //        {
    //            doneEvents[i] = new ManualResetEvent(false);
    //            Fibonacci f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
    //            fibArray[i] = f;
    //            ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
    //        }

    //        // Wait for all threads in pool to calculation...
    //        WaitHandle.WaitAll(doneEvents);
    //        Console.WriteLine("All calculations are complete.");

    //        // Display the results...
    //        for (int i = 0; i < FibonacciCalculations; i++)
    //        {
    //            Fibonacci f = fibArray[i];
    //            Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
    //        }
    //    }
    //}
}

