using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "string";
            int i = 12345;
            float f = 9.001f;
            var sin = SingleStatic.instance;
            List<string> listStr = new List<string>();
            for (int ii = 0; ii < 1000000; ii++)
            {
                listStr.Add("string" + ii.ToString());
            }
            sin.WriteLine(str);
            sin.WriteLine(i);
            sin.WriteLine(f);

            double foreenum = sin.ForEnum(listStr);
            Console.ReadLine();
            double foreachenum = sin.ForeachEnum(listStr);
            Console.WriteLine(foreachenum - foreenum);
            Console.ReadLine();
        }

    }
    public class SingleStatic
    {
        public static  SingleStatic instance=null ;
        static SingleStatic()
        {
            
            instance = new SingleStatic  ();
        }
        
        public void WriteLine<T>(T t)
        {
            Console.WriteLine(""+t.GetType().ToString()+"__"+t.ToString());
        }
        public double ForEnum(List<string > listSTR) 
        {
            DateTime beforDT = System.DateTime.Now;
            for (int FE = 0; FE < listSTR.Count; FE++)
            {
                Console.WriteLine(FE);
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            Console.WriteLine("FOR总共花费{0}ms.", ts.TotalMilliseconds);
            return ts.TotalMilliseconds;
        }
        public double ForeachEnum(List<string> listSTR)
        {
            DateTime beforDT = System.DateTime.Now;
            foreach(var FEA in listSTR)
            {
                Console.WriteLine(FEA);
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);

            Console.WriteLine("FOREACH总共花费{0}ms.", ts.TotalMilliseconds);
            return ts.TotalMilliseconds;
        }
    }
/// <summary>
/// 泛型类
/// </summary>
/// <typeparam name="T"></typeparam>
    public class MyList<T> : IEnumerable<T>
    {
        public Node current=null ;
        public Node head;

        public MyList()
        {
            head = null;
        }
        public void  AddList(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;

        }

        public class Node
        {
            private Node next;
            private T date;

            public Node(T T)
            {
                next = null;
                date = T;
            }

            public Node Next { get => next; set => next = value; }
            public T Date { get => date; set => date = value; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            while (current != null)
            {
                yield return current.Date;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
