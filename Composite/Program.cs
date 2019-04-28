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
        static void Main(string[] args)
        {
        }
    }
    public abstract class Graphics
    {
        protected string _name;

        public Graphics(string name)
        {
            _name = name;
        }
        public abstract void Draw();
    }
    public class Picture : Graphics
    {
        public Picture(string name) : base(name) { }
        public override void Draw()
        {
            
        }
        public ArrayList GetChild()
        {

        }
    }
    public class Line : Graphics
    {
        public Line(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("draw" + _name.ToString());
        }
    }
}