using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //对象不同状态对应不同行为：允许一个对象在其内部状态改变时改变它的行为。从而使对象看起来似乎修改了其行为。
    //定义一个context来管理状态给main用，也可以定义状态类后，调用不同的实现类实现状态的切换；
    class Program
    {
        static void Main(string[] args)
        {// Setup context in a state
            Context c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }
    //状态抽象
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
    //环境，存储状态，
    public class Context
    {
        private State _state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
    //状态
    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }
    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }
}

