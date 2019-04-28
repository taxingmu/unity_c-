using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    //运用共享技术有效地支持大量细粒度的对象，解决对象过多的问题
    //条件是，大量的对象，大部分可以外部化，可以按状态分组，每一组都可以以一个对象替代
    //软件系统不可分辨这些对象，不依赖对象的身份
    //相当于一个对象池，可能敌人 ，子弹之类的可以拿来用
    //TODO 可以添加集合来分组和管理，
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweightFactory factory = new FlyweightFactory();

            // Work with different flyweight instances
            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);
        }
    }
    //声明一个接口，通过这个接口flyweight可以直接接收并作用于外部状态。
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
    //实现Flyweight接口，并为内部状态增加存储空间。ConcreteFlyweight对象必须是可以共享的，
    //它所存储的状态必须是内部的，即它必须独立于ConcreteFlyweight对象的场景。
    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }
    //并非所有的Flyweight子类都需要被共享。Flyweight接口使共享成为可能，但它不强制共享。
    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);
        }
    }
    //创建和管理flyweight对象
    public class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }
}
