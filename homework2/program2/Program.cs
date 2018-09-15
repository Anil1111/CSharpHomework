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
            System.Console.Write("数组的最大值为：");
            System.Console.WriteLine(IntArrayFun.GetMax(array));
            System.Console.Write("数组的最小值为：");
            System.Console.WriteLine(IntArrayFun.GetMin(array));
            System.Console.Write("数组的总和为：");
            System.Console.WriteLine(IntArrayFun.GetSum(array));
            System.Console.Write("数组的平均值为：");
            System.Console.WriteLine(IntArrayFun.GetAver(array));
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
        public static double GetAver(int[] array,int count=0)
        {
            if(count == 0)
            {
                count = array.Length;
            }
            double average =(double) GetSum(array) / count;
            return average;
        }
    }
}
