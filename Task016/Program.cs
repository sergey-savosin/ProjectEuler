using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task016
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 550;
            const int NIter = 1000;

            int[] ar = new int[N];

            // Init array
            for (int i = 0; i<N; i++)
            {
                ar[i] = 0;
            }
            ar[N - 1] = 1;
            ShowArray(ar, 0, 0);

            long sumOfDigits = 0;
            // Double array
            for (int iter = 1; iter<=NIter; iter++)
            {
                sumOfDigits = MakeDouble(ar);
                //ShowArray(ar, iter, sumOfDigits);
            }
            ShowArray(ar, NIter, sumOfDigits);
        }

        private static long MakeDouble(int[] ar)
        {
            int N = ar.Length;
            int val = 0;
            int add = 0;
            long sum = 0;

            for (int i = N-1; i>=0; i--)
            {
                val = ar[i];
                val = val * 2 + add;
                if (val >= 10)
                {
                    add = 1;
                    val -= 10;
                }
                else
                {
                    add = 0;
                }
                ar[i] = val;
                sum += val;
            }

            return sum;
        }

        static void ShowArray(int[] a, int iter, long sumOfDigits)
        {
            Console.Write($"{iter,3}. [{sumOfDigits,5}] ");


            for (int i=0; i<a.Length; i++)
            {
                Console.Write($"{a[i],3}");
                if ((i+1) % 30 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
