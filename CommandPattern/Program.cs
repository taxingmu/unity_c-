using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化
//将命令执行-中间沟通-发布隔离，命令执行事件可以继续抽象，以实现拓展
//对请求排队或记录请求日志，以及支持可撤消的操作。
//命令发出责任和执行者责任分开
namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }/// <summary>
     /// Command角色
     /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// ConcreteCommand角色A
    /// </summary>
    public class ConcreteCommandA : ICommand
    {
        private Receiver receiver = null;

        public ConcreteCommandA(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.DoA();
        }
    }

    /// <summary>
    /// ConcreteCommand角色B
    /// </summary>
    public class ConcreteCommandB : ICommand
    {
        private Receiver receiver = null;

        public ConcreteCommandB(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.DoB();
        }
    }

    /// <summary>
    /// Receiver角色
    /// </summary>
    public class Receiver
    {
        public void DoA()
        {
            //DoSomething
        }

        public void DoB()
        {
            //DoSomething
        }
    }

    /// <summary>
    /// Invoker角色
    /// </summary>
    public class Invoker
    {
        private ICommand command = null;

        //设置命令
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
        //执行命令
        public void RunCommand()
        {
            command.Execute();
        }
    }

    /// <summary>
    /// 客户端调用
    /// </summary>
    public class Client
    {
        public Client()
        {
            Receiver receiver = new Receiver();
            Invoker invoker = new Invoker();
            invoker.SetCommand(new ConcreteCommandA(receiver));
            invoker.RunCommand();
            invoker.SetCommand(new ConcreteCommandB(receiver));
            invoker.RunCommand();
        }
    }
}
