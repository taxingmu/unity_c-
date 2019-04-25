using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
//其核心思想是分离了生产厂家，同时也分离生产产品
//比如生产红旗车，产品我还未确定，所以确定接口，方便增删配件等只需改一个地方。
//工厂呢对工序进行排列，但是对工序顺序，增删等方便操作，将工厂和那些复杂的操作分离开
//代码维护上很清晰，需要什么功能就能方便修改
namespace FactoryMethod
{
   class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Factory Method No:");
            Console.WriteLine("******************************");
            Console.WriteLine("no         Factory Method");
            Console.WriteLine("1          HongQiCarFactory");
            Console.WriteLine("2          BMWCarFactory");
            Console.WriteLine("******************************");
            int no = Int32.Parse(Console.ReadLine().ToString());
            string factoryType = ConfigurationManager.AppSettings["No" + no];
            //CarFactory factory = new HongQiCarFactory();
            CarFactory factory = (CarFactory)Assembly.Load("FactoryMehtod").CreateInstance("FactoryMehtod." + factoryType); ;
            Car car = factory.CarCreate();
            car.StartUp();
            car.Run();
            car.Stop();
            
        }
}
    public abstract class CarFactory
    {
        public abstract Car CarCreate();
    }
    public abstract class Car
    {
        public abstract void StartUp();
        public abstract void Run();
        public abstract void Stop();

    }
    public class HongQiCarFactory : CarFactory
    {
        public override Car CarCreate()
        {
            return new HongQiCar();
        }
    }
    public class BMWCarFactory : CarFactory
    {
        public override Car CarCreate()
        {
            return new BMWCar();
        }
    }
    public class HongQiCar : Car
    {
        public override void StartUp()
        {
            Console.WriteLine("Test HongQiCar start-up speed!");
        }
        public override void Run()
        {
            Console.WriteLine("The HongQiCar run is very quickly!");
        }
        public override void Stop()
        {
            Console.WriteLine("The slow stop time is 3 second ");
        }
    }
    public class BMWCar : Car
    {
        public override void StartUp()
        {
            Console.WriteLine("The BMWCar start-up speed is very quickly");
        }
        public override void Run()
        {
            Console.WriteLine("The BMWCar run is quitely fast and safe!!!");
        }
        public override void Stop()
        {
            Console.WriteLine("The slow stop time is 2 second");
        }
    }
}
