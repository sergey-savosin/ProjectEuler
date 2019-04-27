using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task020
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 101;
            BigInteger f = 1;
            BigInteger f2 = 1;

            for (int i = 1; i<N; i++)
            {
                f *= i;
                f2 *= i;
                while ((f2 - f2 / 10 * 10) == 0)
                    f2 /= 10;
                Console.WriteLine($"{i,3}: {f,5}, {f2,4}");
            }

            Console.WriteLine($"last f2: {f2}");
            int numLen = f2.ToString().Length;
            Console.WriteLine($"f2 len: {numLen}");
            int sum = 0;
            foreach (char ch in f2.ToString())
            {
                Console.Write($"{ch}.");
                int n = int.Parse(ch.ToString());
                sum += n;
            }

            Console.WriteLine($"sum={sum}");
        }
    }
}
