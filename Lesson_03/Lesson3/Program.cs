using System;
namespace Delegates_Observer
{
    public delegate void MyDelegate<T>(T arg);

    class Observer1 // Наблюдатель 1
    {
        public void DoInt(int n)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", n);
        }
    }
    class Observer2 // Наблюдатель 2
    {
        public void DoDouble(double d)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", d);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            MyDelegate<int> d1 = new MyDelegate<int>(o1.DoInt);
            MyDelegate<double> d2 = o2.DoDouble;
            o1.DoInt(1);
            o2.DoDouble(5.2);
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}