using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{

    public class Invo {

        public void InvokeThis()
        {
            fruit frui = new fruit();
            Console.WriteLine("0");
            Shuiguo aaa = new Shuiguo("ad", "ada");
            Console.WriteLine("1");
            Shuiguo aaaa = new Shuiguo("ada", "ada");
            Console.WriteLine("2");
            frui.adddH(aaa);
            frui.adddH(aaaa);
            foreach(var i in frui)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }

    //迭代器
    class fruit : IEnumerable
    {
       
        public List<Shuiguo> fritus ;

        public fruit()
        {
            fritus = new List<Shuiguo>();
        }
       public void  adddH(Shuiguo sss)
        {
            fritus.Add(sss);
        }
        public IEnumerator GetEnumerator()
        {
            return new FreuitSign(fritus);
        }
    }
    public class Shuiguo
    {
        public string name;
        public string haochi;

        public Shuiguo(string name, string haochi)
        {
            this.name = name;
            this.haochi = haochi;
        }
        public override string ToString()
        {
            return name+haochi;
        }
    }
    //枚举器
    class FreuitSign : IEnumerator
    {

        public List<Shuiguo> fruits;
        int posi = -1;
        public Shuiguo current;
        public Shuiguo next;
        //object IEnumerator.Current => throw new NotImplementedException();

        public FreuitSign(List<Shuiguo > fruitss)
        {
            this.fruits = fruitss;
        }

       object  IEnumerator. Current{
           get { return fruits[posi]; }
         }

        public bool MoveNext()
        {
            Console.WriteLine("ois"+posi+"5");
            posi++;
            if (posi > fruits.Count-1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            posi = -1;
        }
    }
}
