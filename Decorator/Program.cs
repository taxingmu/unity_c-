using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        //主体上加一些配料，比如饼 加配菜，比继承更有弹性
        //或者多重继承：一层层的扩展功能，通过继承类
        //比如孙悟空七十二变，抽象它的变化。具体实现继承。但是对如飞行行走，游动，可以定义为接口，变化后清除，然后add飞行，行走，游动，或者飞行加游动
        static void Main(string[] args)
        {
            CanMove move = new Fish("孙悟空");

        }
    }
    //拥有什么技能
    public  abstract class  CanMove {

        public  string name;
        public List<string> canDo;
        public abstract void  Move();
    }
    //鱼儿
    public class Fish : CanMove
    {
        public Fish(string NameStr)
        {
            canDo = null;
            name = NameStr;
        }

        public override void Move()
        {
            canDo.Add("fly");
            canDo.Add("swiming");
        }
    }
}
