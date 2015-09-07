using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var food1= SimpleFactory.CreateFood(1);
            food1.MakeFood();

            var food2 = SimpleFactory.CreateFood(2);
            food2.MakeFood();

            Console.Read();
        }
    }

    public abstract class Food
    {
        public abstract void MakeFood();
    }

    public class MakeTomato : Food
    {
        public override void MakeFood()
        {
            Console.WriteLine("番茄");
        }
    }

    public class MakePotato : Food
    {
        public override void MakeFood()
        {
            Console.WriteLine("土豆");
        }
    }

    public class SimpleFactory
    {
        public static Food CreateFood(int type)
        {
            Food food = null;
            if (type == 1)
            {
                food = new MakePotato();
            }
            else if(type==2)
            {
                food=new MakeTomato();
            }
            return food;

        }
    }
}
