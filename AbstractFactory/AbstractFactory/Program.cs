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


            AbstractFactory fc3 = new CF();
            Client1 client1 = new Client1(fc3);
            client1.Run();
            Console.ReadLine();
        }
    }
    //对象说我需要什么抽象产品》》》》产品类的对象接口》》》实现类；也可以继承

    //初步的理解
    //比如说一个自行车制造商，共享单车是一个ConcreteFactory，童车也是一个ConcreteFactory
    //当我需要童车时候，新建童车产品线，但是不一定去生产，下达生产指令后，调用Product
    //个人认为适合于类似于这种东西我可能需要多种规格的，但是都是这样组合（也可以更改client添加方法多种配置和多种规格）
    //相当于公司老总给车间主任说需要什么配件，车间主任指挥工人打造什么规格的配件，工人具体打造配件
    //ConcreteFactory相当于产线搭配，具体简配本例使用client1
    //创建一个AbstractFactory的时候，相当于创造了一个全配件的东西，后期我们可以根据client简配，不初始化某些配件，也不生产了，充分发挥工厂模式的多样化
    //最终理解：
    //指出一个工厂线拥有的所有能力AbstractFactory，然后创造多个不同规格生产线ConcreteFactory：AbstractFactory
    //采购方选择想要配置,如果这个配置经常需要，就把它写成client，这样这个客户要这个，直接调用，相当于对这个生产线的组合产品生产的封装；
    //声明一个创建抽象产品对象的操作接口
    //指出这个生产线拥有全部的能力
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
    //声明一类产品对象接口
    abstract class AbstractProductA
    {
        public abstract void Interact( );
    }
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    //不同客户需求搭配不一样，想当与购买者，从生产线拥有的能力中选自己需要的生产线，可以灵活初始化，初始化后投产也是client说了算
    class Client1
    {
        private AbstractProductA AbstractProductA;
        public Client1(AbstractFactory factory)//提供创造产品方法
        {
            AbstractProductA = factory.CreateProductA();
        }
        public void Run()
        {
            //AbstractProductB.Interact(AbstractProductA);
           AbstractProductA.Interact();
        }
    }
    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;
        public Client(AbstractFactory factory)//提供创造产品方法
        {
            AbstractProductA = factory.CreateProductA();
            AbstractProductB = factory.CreateProductB();
        }
        public void Run()
        {
            AbstractProductB.Interact(AbstractProductA);
            AbstractProductA.Interact();
        }
    }
    //相当于指出这个生产线在哪里
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
    class CF : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            throw new NotImplementedException();
        }
    }
    //具体生产线，继承那个生产线就是那个生产线的类型的具体生产方法
    class ProductA1 : AbstractProductA
    {
        public override void Interact()
        {
            Console.WriteLine(this.GetType().Name + "interact with" );
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
        public override void Interact()
        {
            Console.WriteLine(this.GetType().Name + "interact with" );
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
