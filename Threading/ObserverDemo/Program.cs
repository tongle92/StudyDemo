using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            Display display = new Display();

            //注册警报方法
            // heater.BoilEvent += alarm.MakeAlert;
            //注册显示方法
            heater.BoilEvent += display.ShowMsg;
            //给匿名对象注册方法
            // heater.BoilEvent += new Alarm().MakeAlert;

            heater.Boil();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 热水器类
    /// </summary>
    public class Heater
    {
        //温度
        private int temperature;
        //声明委托
        public delegate void BoilHandler(int temperature);
        //声明事件
        public event BoilHandler BoilEvent;

        /// <summary>
        /// 加热方法
        /// </summary>
        public void Boil()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (BoilEvent != null)
                    BoilEvent(temperature);
                if (temperature >= 95)
                {
                    //当大于95注册警报方法
                    BoilEvent = new Alarm().MakeAlert;
                }
            }
        }

    }

    /// <summary>
    /// 热水器类
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 创建警报
        /// </summary>
        /// <param name="temoerature"></param>
        public void MakeAlert(int temperature)
        {
            Console.WriteLine("警报：水已经{0}度了", temperature);
        }
    }

    /// <summary>
    /// 显示器类
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 显示消息类
        /// </summary>
        /// <param name="temperature"></param>
        public void ShowMsg(int temperature)
        {
            Console.WriteLine("提示当前水温{0}了", temperature);
        }
    }
}
