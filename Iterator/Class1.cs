using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Class1
    {
    }
    class Fruit : IEnumerable
    {
        public List<string> items = new List<string>();

        public Fruit()
        {
            items = null;
        }

        public IEnumerator GetEnumerator()
        {
            return new  FruitItor();
        }
    }
    class FruitItor : IEnumerator
    {
        
        public  FruitItor()
        {
            this;
        }

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
