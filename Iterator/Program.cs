using System;
using System.Collections;

namespace Iterator
{
    public class Program
    {
        
        static void  Main(string[] args)
        {
            Person[] pArray = new Person[]
            {
                new Person("July","Wu"),
                new Person("Joyn","Wu"),
                new Person("John","Wu")
            };
            Invo invo = new Invo();
            invo.InvokeThis();
            foreach (Person i in pArray)
            {
                Console.WriteLine(i);
            }
             Console.ReadLine();
        }
    }
    //用户类
    public class Person
    {
        public string firstName;
        public string lastName;
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
    //实现了IEnumerable接口的用户数组的类,迭代
    public class People : IEnumerable
    {
        private Person[] people;
        public People(Person[] pArray)
        {
            people = new Person[pArray.Length];
            for (int i = 0; i < pArray.Length; i++)
            {
                people[i] = new Person(pArray[i].firstName, pArray[i].lastName);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()//显示的实现了接口中的GetEnumerator（）方法
        {
            return (IEnumerator)GetEnumerator();
        }
        public IEnumerator GetEnumerator()//方法的真正实现
        {
            return new PeoEnum(people);
        }
    }
    //枚举IQ
    public class PeoEnum : IEnumerator
    {
        public Person[] people;
        int position = -1;//当前指向的元素的前面一个元素
        public PeoEnum(Person[] people)
        {
            this.people = people;
        }
        public bool MoveNext()//判断是否还有元素
        {
            position++;
            return (position < people.Length);
        }
        public void Reset()//重置
        {
            position = -1;
        }
        object IEnumerator.Current//返回当前元素的对象
        {
            get
            {
                return Current;
            }
        }
        public Person Current
        {
            get
            {
                try
                {
                    return people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }

            }
        }
    }
}