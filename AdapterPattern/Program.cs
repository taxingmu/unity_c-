using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    //适用场景，如果电压标准不统一，输入不一样保证输出一样
    //类的外观不变，但是已经被改的面目全非，只提供接口给实现类即可，提供虚函数，然后实现类实现虚函数即可，引用了对象所以是对象适配器的实现
    //分为类的适配和对象适配
    //相当于把以前提供的方法抽象成接口，新的实现同样功能的类继承并实现即可
    class Program
    {
        static void Main(string[] args)
        {//实例化一个适配器给目标接口 
            Adapter target = new Adapter();
            //下面的这些就是客户端可以被识别了接口了
            target.GetTemperature();
            target.GetPressure();
            target.GetHumidity();
            target.GetUltraviolet();
            Console.ReadKey();
        }
    }
    public abstract class Target
    {
        //温度 
        /// <summary> 
        /// 下面的接口才是可以被客户端所识别的接口，也就是目标接口 
        /// 而前面在被适配器类中的中文却不能被客户端识别，需要被适配 
        /// </summary> 
        public abstract void GetTemperature();
        //气压 
        public abstract void GetPressure();
        //湿度 
        public abstract void GetHumidity();
        //紫外线强度 
        public abstract void GetUltraviolet();
    }
    class Adaptee
    {
        /// <summary> 
        /// 在被适配器类中的接口并不是客户端需要的接口 
        /// 比如这里是使用的中文，而我在客户端却必须要使用英文 
        /// 所以在这里我必须使用适配器来适配 
        /// </summary> 
        public void 得到温度()
        {
            Console.WriteLine("您得到了今日的温度");
        }
        public void 得到气压()
        {
            Console.WriteLine("您得到了今日的气压");
        }
        public void 得到湿度()
        {
            Console.WriteLine("您得到了今日的湿度");
        }
        public void 得到紫外线强度()
        {
            Console.WriteLine("您得到了今日的紫外线强度");
        }
    }
    public class Adapter : Target
    {
        //在适配器中必须要维护一个被适配器类的对象 
        private Adaptee adaptee = new Adaptee();
        /// <summary> 
        /// 通过适配器来适配原来不能被客户端所认识的接口 
        /// </summary> 
        public override void GetTemperature()
        {
            adaptee.得到温度();
        }
        public override void GetPressure()
        {
            adaptee.得到气压();
        }
        public override void GetHumidity()
        {
            adaptee.得到湿度();
        }
        public override void GetUltraviolet()
        {
            adaptee.得到紫外线强度();
        }
    }
}

