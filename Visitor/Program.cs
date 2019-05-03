using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    //原有类中天添加方法，适用于数据结构稳定的系统，降低数据结构作用与操作的解耦
    //把访问者抽象，在访问者中实现方法，将访问者传入数据结构中，调用访问者方法来处理元素
    //重要地方在，数据结构的accept方法接受到一个访问者，这个访问者根据抽象的数据结构有不同的处理方法给数据结构
    //重要地方在于2：元素的方法接受到访问者，利用访问者的多态找到合适的方法，调用访问者方法处理自身数据，堪称魔术大师
        // 抽象元素角色
        public abstract class Element
        {
            public abstract void Accept(IVistor vistor);
            public abstract void Print();
        }

        // 具体元素A
        public class ElementA : Element
        {
            public override void Accept(IVistor vistor)
            {
                // 调用访问者visit方法
                vistor.Visit(this);
            }
            public override void Print()
            {
                Console.WriteLine("我是元素A");
            }
        }

        // 具体元素B
        public class ElementB : Element
        {
            public override void Accept(IVistor vistor)
            {
                vistor.Visit(this);
            }
            public override void Print()
            {
                Console.WriteLine("我是元素B");
            }
        }
    public class Ec : Element
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("ccc");
        }
    }

    // 抽象访问者
    public interface IVistor
        {
            void Visit(ElementA a);
            void Visit(ElementB b);
        void Visit(Ec c);
        }

        // 具体访问者
        public class ConcreteVistor : IVistor
        {
            // visit方法而是再去调用元素的Accept方法
            public void Visit(ElementA a)
            {
                a.Print();
            }
            public void Visit(ElementB b)
            {
                b.Print();
            }

        public void Visit(Ec c)
        {
            c.Print();
        }
    }

        // 对象结构
        public class ObjectStructure
        {
            private ArrayList elements = new ArrayList();

            public ArrayList Elements
            {
                get { return elements; }
            }

            public ObjectStructure()
            {
                Random ran = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int ranNum = ran.Next(10);
                    if (ranNum > 5)
                    {
                        elements.Add(new ElementA());
                    }
                    else
                    {
                        elements.Add(new ElementB());
                    }
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ObjectStructure objectStructure = new ObjectStructure();
                foreach (Element e in objectStructure.Elements)
                {
                    // 每个元素接受访问者访问
                    e.Accept(new ConcreteVistor());
                }

                Console.Read();
            }
        }
    
}
