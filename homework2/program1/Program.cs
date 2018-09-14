using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Factors number = new Factors(100);
            number.FindTheFactors();
        }
    }

    class Factors
    {
        private int number;
        private string output;
        public Factors(int number)
        {
            this.number = number;
            output = "number = ";
        }
        public void FindTheFactors()
        {
            int i=2;
            int count = number;
            while(1!=count)
            {
                
                while(count%i!=0)
                {
                    i++;
                }
                count = count / i;
                if(count==1)
                {
                    output += i;

                }
                else
                {
                    output += i + " * ";
                }
                i = 2;
            }
            System.Console.WriteLine(output);
        }
    }
}
