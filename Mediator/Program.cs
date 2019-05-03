﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    //用一个中介封装一系列对象交互。终结者使用对象不需要相互引用，从而使其松散耦合，而且可以独立改变交互
    //想定制一个位于多个类中的行为，但是又不好生成太多子类
    //用户类 中介者类
    // 抽象牌友类
    //利用中介者处理对象间的交互，相当于平台或者居间人
public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }
        protected AbstractCardPartner()
        {
            MoneyCount = 0;
        }
        public abstract void ChangeCount(int count, AbstractCardPartner other);
    }

    // 牌友A类
    public class ParterA : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractCardPartner other)
        {
            this.MoneyCount += count;
            other.MoneyCount -= count;
        }
    }

    // 牌友B类
    public class ParterB : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractCardPartner other)
        {
            this.MoneyCount += count;
            other.MoneyCount -= count;
        }
    }

    class Program
    {
        // A,B两个人打牌
        static void Main(string[] args)
        {
            AbstractCardPartner A = new ParterA();
            A.MoneyCount = 20;
            AbstractCardPartner B = new ParterB();
            B.MoneyCount = 20;

            // A 赢了则B的钱就减少
            A.ChangeCount(5, B);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B赢了A的钱也减少
            B.ChangeCount(10, A);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount); // 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
            Console.Read();
        }
    }
namespace MediatorPattern
    {
        // 抽象牌友类
        public abstract class AbstractCardPartner
        {
            public int MoneyCount { get; set; }

            protected AbstractCardPartner()
            {
                MoneyCount = 0;
            }

            public abstract void ChangeCount(int count, AbstractMediator mediator);
        }

        // 牌友A类
        public class ParterA : AbstractCardPartner
        {
            // 依赖与抽象中介者对象
            public override void ChangeCount(int count, AbstractMediator mediator)
            {
                mediator.AWin(count);
            }
        }

        // 牌友B类
        public class ParterB : AbstractCardPartner
        {
            // 依赖与抽象中介者对象
            public override void ChangeCount(int count, AbstractMediator mediator)
            {
                mediator.BWin(count);
            }
        }

        // 抽象中介者类
        public abstract class AbstractMediator
        {
            protected AbstractCardPartner A;
            protected AbstractCardPartner B;

            protected AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
            {
                A = a;
                B = b;
            }

            public abstract void AWin(int count);
            public abstract void BWin(int count);
        }

        // 具体中介者类
        public class MediatorPater : AbstractMediator
        {
            public MediatorPater(AbstractCardPartner a, AbstractCardPartner b)
                : base(a, b)
            {
            }

            public override void AWin(int count)
            {
                A.MoneyCount += count;
                B.MoneyCount -= count;
            }

            public override void BWin(int count)
            {
                B.MoneyCount += count;
                A.MoneyCount -= count;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                AbstractCardPartner A = new ParterA();
                AbstractCardPartner B = new ParterB();
                // 初始钱
                A.MoneyCount = 20;
                B.MoneyCount = 20;

                AbstractMediator mediator = new MediatorPater(A, B);

                // A赢了
                A.ChangeCount(5, mediator);
                Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
                Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

                // B 赢了
                B.ChangeCount(10, mediator);
                Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是15
                Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
                Console.Read();
            }
        }
    }
}
