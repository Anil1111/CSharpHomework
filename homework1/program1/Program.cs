using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.show();
            A b = new B();
            b.show();
            Console.WriteLine("HelloWorld!");
            Console.WriteLine("Please input two numbers:");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Their product is " + (x * y));
        }
    }

    class A
    {
        public void show()
        {
            Console.WriteLine("A");
        }
    }
    
    class B : A
    {
        public void show()
        {
            Console.WriteLine("B");
        }
    }
}
