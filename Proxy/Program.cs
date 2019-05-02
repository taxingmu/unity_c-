using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//为其他对象提供一种代理以控制对这个对象的访问
namespace Proxy
{
    //对复杂的软件系统常有一种处理手法，即增加一层间接层，从而对系统获得一种更为灵活、
    //满足特定需求的解决方案，把更多精力放在业务上而不是具体实现，以及对数据的一些处理等
    //大多数情况下啊会让实现类和代理类继承同一个接口，保证对对象的透明性，不一定非要这么做
    //如联网中用户获取等，代理类得到，实现交给网络层，代理可以共享给ui等，
    class Program
    {
        static void Main(string[] args)
        {
                    Math math = new Math();
           
       // 对接收到的结果数据进行解包

       double addresult = math.Add(2, 3);
       
       double subresult = math.Sub(6, 4);
       
       double mulresult = math.Mul(2, 3);
      
       double devresult = math.Dev(2, 3);
        }
    }
     public class MathProxy
 {
     private Math math = new Math();
 
     // 以下的方法中，可能不仅仅是简单的调用Math类的方法
 
     public double Add(double x, double y)
     {
         return math.Add(x, y);
     }
 
     public double Sub(double x, double y)
     {
         return math.Sub(x, y);
     }
 
     public double Mul(double x, double y)
     {
         return math.Mul(x, y);
     }
 
     public double Dev(double x, double y)
     {
         return math.Dev(x, y);
     }
    }
     public interface IMath
 {
     double Add(double x, double y);
 
     double Sub(double x, double y);
 
     double Mul(double x, double y);
 
     double Dev(double x, double y);
 }
 
 //Math类和MathProxy类分别实现IMath接口：
     public class Math
 {
     public double Add(double x, double y)
     {
         return x + y;
     }
 
     public double Sub(double x, double y)
     {
         return x - y;
     }
 
     public double Mul(double x, double y)
     {
         return x* y;
     }
 
     public double Dev(double x, double y)
     {
         return x / y;
     }
 }
}
