using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    //组合模式又叫部分整体模式，在树结构问题中，模糊简单元素与复杂元素，处理简单一样处理复杂，是内部解耦
    //使得用户对单个对象和组合对象的使用具有一致性。
    class Program
    {
        //使用公司类抽象，总公司和分公司等都抽象
        static void Main(string[] args)
        {
            ConcreteCompany root = new ConcreteCompany("北京总共司");
            root.Add(new HRdepartment("人力部"));
            root.Add(new FinanceDepartment("财务部"));
            ConcreteCompany comp = new ConcreteCompany("上海分公司");
            comp.Add(new HRdepartment("分工司人力部"));
            comp.Add(new FinanceDepartment("分公司财务部"));
            root.Add(comp);
            ConcreteCompany comp1 = new ConcreteCompany("南京分部");
            comp1.Add(new HRdepartment("南京人力部"));
            comp1.Add(new FinanceDepartment("南京财务部"));
            comp.Add(comp1);
            ConcreteCompany comp2 = new ConcreteCompany("杭洲分部");
            comp2.Add(new HRdepartment("杭州人事部"));
            comp2.Add(new FinanceDepartment("杭州财务部"));
            comp.Add(comp2);
            root.Display(1);
            Console.ReadKey();
        }
    }
    //抽象公司类
    public abstract class Company
    {
        protected string name;
        public Company(string name)
        {
            this.name = name;
        }
        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();
    }
    //抽象的公司具体操作类
    public class ConcreteCompany : Company
    {
        private List<Company> children = new List<Company>();
        public ConcreteCompany(string name)
          : base(name)
        { }
        public override void Add(Company c)
        {
            children.Add(c);
        }
        public override void Remove(Company c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (Company component in children)
            {
                component.Display(depth + 2);
            }
        }
        public override void LineOfDuty()
        {
            foreach (Company component in children)
            {
                component.LineOfDuty();
            }
        }
    }
    //财务部
    public class FinanceDepartment : Company
    {
        public FinanceDepartment(string name) : base(name) { }
        public override void Add(Company c)
        {
        }
        public override void Remove(Company c)
        {

        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 财务支付管理", name);
        }
    }
    //人事部
    public class HRdepartment : Company
    {
        public HRdepartment(string name)
          : base(name)
        { }
        public override void Add(Company c)
        {
        }
        public override void Remove(Company c)
        {
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 招聘培训管理", name);
        }
    }
}