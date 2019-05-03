using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //定义一个系统的算法，把他们一个个封装起来，并且可以相互替换，本模式可以使用它独立于客户变化
    //抽象算法类，用角色持有的类找到合适的算法使用
    //抽象算法，实现算法，角色构造函数拥有抽象的算法接口，返回指定算法，而不用更改代码，
    //修改只需修改算法，修改引用即可
    namespace StrategyPattern
    {
        // 所得税计算策略
        public interface ITaxStragety
        {
            double CalculateTax(double income);
        }

        // 个人所得税
        public class PersonalTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return income * 0.12;
            }
        }

        // 企业所得税
        public class EnterpriseTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
            }
        }

        public class InterestOperation
        {
            private ITaxStragety m_strategy;
            public InterestOperation(ITaxStragety strategy)
            {
                this.m_strategy = strategy;
            }

            public double GetTax(double income)
            {
                return m_strategy.CalculateTax(income);
            }
        }

        class App
        {
            static void Main(string[] args)
            {
                // 个人所得税方式
                InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
                Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

                // 企业所得税
                operation = new InterestOperation(new EnterpriseTaxStrategy());
                Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));

                Console.Read();
            }
        }
    }
}
