using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 表示被构造的复杂对象。ConcreteBuilder创建该产品的内部表示并定义它的装配过程
    // 包含定义组成部件的类，包括将这些部件装配成最终产品的接口//
    //首先确定产品类product，由builder确定你应该需要什么配件，ConcreteBuilder负责实施（生产线），
    public class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Product Parts");
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }
    //为创建一个Product对象的各个部件指定抽象接口；
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
    // ° 实现Builder的接口以构造和装配该产品的各个部件

    ///　° 定义并明确它所创建的表示

    //　° 提供一个检索Product的接口
    public class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
    public class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartX");
        }

        public override void BuildPartB()
        {
            _product.Add("PartY");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
    public class ConcreteBuilder3 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("月亮");
        }

        public override void BuildPartB()
        {
            _product.Add("火星");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
    //构造一个使用Builder接口的对象；
    public class Director
    {
        /// <summary>
        /// Builder uses a complex series of steps
        /// </summary>
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create director and builders
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            Builder b3 = new ConcreteBuilder3();

            director.Construct(b3);
            Product pp = b3.GetResult();
            pp.Show();
            // Construct two products
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();


            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
            Console.ReadLine();
        }
    }
}
