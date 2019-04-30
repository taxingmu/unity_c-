using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    //迭代器
    class fruit : IEnumerable
    {
        public List<Shuiguo> fritus ;

        public fruit()
        {
            fritus = null;
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
           get { return current; }
         }

        public bool MoveNext()
        {
            if (posi > fruits.Count)
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
