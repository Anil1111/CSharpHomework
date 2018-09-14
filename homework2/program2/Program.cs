using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            for(int i=0;i<array.Length;i++)
            {
                array[i] = i;
            }
            System.Console.Write(IntArrayFun.GetAver(array,array.Length));
        }
    }

    class IntArrayFun
    {
        public static int GetMax(int[] array)
        {
            int max = array[0];
            foreach(int i in array)
            {
                if(array[i]>max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        public static int GetMin(int[] array)
        {
            int min = array[0];
            foreach (int i in array)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        public static long GetSum(int[] array)
        {
            long sum = 0;
            foreach (int i in array)
            {
                sum += array[i];
            }
            return sum;
        }
        public static double GetAver(int[] array,int count=1)
        {
            double average =(double) GetSum(array) / count;
            return average;
        }
    }
}
