using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    //桥接模式想当与把二个东西组合在一起，，如笔刷大小和色彩
    //这样只用实现笔刷抽象类和彩色抽象类去实现，就可以了，方便分项扩展，需要什么添加什么就行

    class Program
    {
        static void Main(string[] args)
        {
            Brush b = new BigBrush();
            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();

            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();
        }
    }
    abstract class Brush
    {
        protected Color c;
        public abstract void Paint();

        public void SetColor(Color c)
        { this.c = c; }
    }
    class BigBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using big brush and color {0} painting", c.color); }
    }
    class SmallBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using small brush and color {0} painting", c.color); }
    }

    class Color
    {
        public string color;
    }
    class Red : Color
    {
        public Red()
        { this.color = "red"; }
    }
    class Green : Color
    {
        public Green()
        { this.color = "green"; }
    }
    class Blue : Color
    {
        public Blue()
        { this.color = "blue"; }
    }
}
