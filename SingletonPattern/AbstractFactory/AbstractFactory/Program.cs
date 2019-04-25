using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Abstractfactory1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();
            // Abstractfactory2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();
            Console.ReadLine();
        }
    }
    //对象说我需要什么抽象产品》》》》产品类的对象接口》》》实现类；也可以继承
    //比如说一个自行车制造商，共享单车是一个ConcreteFactory，童车也是一个ConcreteFactory
    //当我需要童车时候，新建童车产品线，但是不一定去生产，下达生产指令后，调用Product
    //个人认为适合于类似于这种东西我可能需要多种规格的，但是都是这样组合（也可以更改client添加方法多种配置和多种规格）
    //相当于公司老总给车间主任说需要什么配件，车间主任指挥工人打造什么规格的配件，工人具体打造配件
    //声明一个创建抽象产品对象的操作接口
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
    //声明一类产品对象接口
    abstract class AbstractProductA
    {
        public abstract void Interact(AbstractProductB b);
    }
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;
        public Client(AbstractFactory factory)
        {
            AbstractProductA = factory.CreateProductA();
            AbstractProductB = factory.CreateProductB();
        }
        public void Run()
        {
            AbstractProductB.Interact(AbstractProductA);
            AbstractProductA.Interact(AbstractProductB);
        }
    }
    //实现创建具体产品对象的操作
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProdcutA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
    class ProductA1 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }
    class ProdcutA2 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }
}
