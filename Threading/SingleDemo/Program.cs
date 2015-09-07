using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var online = OnlineCount.GetOnLineCount();
            online.DeCreaseNum();
            online.DeCreaseNum();
            online.DeCreaseNum();

            Console.WriteLine(online.GetNum());

            var lazyOnLine = LazyOnlineCount.GetLazyOnLineCount();
            lazyOnLine.Add();
            lazyOnLine.Add();
            Console.WriteLine(lazyOnLine.GetNum());



            Console.ReadLine();
        }
    }


    public class OnlineCount
    {

        public static readonly OnlineCount _onLineCount = new OnlineCount();
        private int num = 0;
        private OnlineCount()
        {
            this.num = 10;
        }

        public static OnlineCount GetOnLineCount()
        {
            return _onLineCount;
        }

        public void IncreaseNum()
        {
            this.num++;
        }

        public void DeCreaseNum()
        {
            this.num--;
        }


        public int GetNum()
        {
            return num;
        }


    }

    public class LazyOnlineCount
    {
        private static LazyOnlineCount _lazyCount;
        private static object _lock=new object();
        private int num;

        private LazyOnlineCount()
        {
            this.num = 10;
        }

        public static LazyOnlineCount GetLazyOnLineCount()
        {
            if (_lazyCount == null)
            {
                lock (_lock)
                {
                    if (_lazyCount == null)
                    {
                        _lazyCount = new LazyOnlineCount();
                    }
                }
            }

            return _lazyCount;
        }

        public void Add()
        {
            this.num++;
        }

        public void Less()
        {
            this.num--;
        }

        public int GetNum()
        {
            return this.num;

        }
    }
}
