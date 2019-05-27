using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task025
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a1, a2, a3, iter = 0;
            const int N = 6000;

            a1 = 1;
            a2 = 1;
            iter = 2;
            while (iter<N)
            {
                iter++;
                a3 = a1 + a2;
                // get length
                int d = GetDigitsNum(a3);

                Console.Write("{0}) {1} - {2}. ", iter, a3, d);
                if (iter % 2 == 0)
                    Console.WriteLine();

                // correct
                a1 = a2;
                a2 = a3;

                if (d >= 1000)
                    break;
            }
        }

        static int GetDigitsNum(BigInteger n)
        {
            int digits = 0;

            while (n > 0)
            {
                digits++;
                n = n / 10;
            }

            return digits;
        }
    }
}
