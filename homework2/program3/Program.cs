using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000;
            int[] factors = PrimeSieve.GetTheSieve(n);
            System.Console.WriteLine(n+"以内的素数有：");
            foreach(int i in factors)
            {
                System.Console.Write(i + " ");
            }
        }
        
    }

    class PrimeSieve
    {
        public static int[] GetTheSieve(int number)
        {
            int[] factors = new int[number+1];
            int count = 1;
            factors[0] = -1;
            factors[1] = 1;
            for(int i = 2; i < factors.Length;i++)
            {
                if(factors[i]!=-1)
                {
                    count++;
                    factors[i] = i;
                }
                for(int j = i; i * j < factors.Length; j++)
                {
                    factors[i * j] = -1;
                }
            }
            int[] results = new int[count];
            count = 0;
            for(int i = 0;i<factors.Length;i++)
            {
                if (factors[i] != -1)
                {
                    results[count] = factors[i];
                    count++;
                }
            }
            return results;
        } 
    }
}
