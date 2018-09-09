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
            Console.WriteLine("HelloWorld!");
            Console.WriteLine("Please input two numbers:");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Their product is " + (x * y));
        }
    }
}
