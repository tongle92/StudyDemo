using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverHeaterDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            Display display = new Display();

            //注册方法
            heater.Boil+= alarm.MakeAlert;
            heater.Boil += display.ShowMsg;

            Console.WriteLine("开始执行");
            heater.BoilWater();
            Console.Read();
        }
    }

    /// <summary>
    ///热水器类
    /// </summary>
    public class Heater
    {
        //温度
        private int temperature;
        //型号
        public string type = "Noo1";
        //产地
        public string area = "su zhou";

        //声明委托
        public delegate void BoilEventHandler(object sender, BoilEventArgs e);
        //声明时间
        public event BoilEventHandler Boil;

        //定义BoilEventArgs 包含监事对象感兴趣的东西
        public class BoilEventArgs : EventArgs
        {
            //温度
            public readonly int temperature;

            //构造函数
            public BoilEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        //供子类继承重写
        protected virtual void OnBoiled(BoilEventArgs e)
        {
            if (Boil != null)
                Boil(this, e);
        }


        //加热方法
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //构造对象
                    BoilEventArgs e = new BoilEventArgs(temperature);
                    //调用OnBoiled方法
                    OnBoiled(e);
                }

            }
        }
    }

    //警报器类
    public class Alarm
    {
        //警报方法
        public void MakeAlert(object sender ,Heater.BoilEventArgs e) {
            Heater heater = (Heater)sender;
            //访问heater类中属性
            Console.WriteLine("警报器:热水器的产地：{0}",heater.area);
            Console.WriteLine("警报器:热水器的型号：{0}", heater.type);
            Console.WriteLine("警报器:热水器当前温度：{0}", e.temperature);
        }
    }

    //显示器类
    public class Display
    {
        //显示器方法
        public void ShowMsg(object sender, Heater.BoilEventArgs e)
        {
            Heater heater = (Heater)sender;
            //访问heater类中属性
            Console.WriteLine("显示器:热水器的产地：{0}", heater.area);
            Console.WriteLine("显示器:热水器的型号：{0}", heater.type);
            Console.WriteLine("显示器:热水器当前温度：{0}", e.temperature);
        }
    }
}
