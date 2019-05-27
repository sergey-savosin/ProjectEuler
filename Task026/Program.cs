using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task026
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 8;
            for (int n=6; n<N; n++)
            {
                BigInteger rationalPart;
                int skipTens;
                int ratLength = GetRationalLength(n, out rationalPart, out skipTens);
                Console.WriteLine("{0}. {1} : {2} skip {3}", n, ratLength, rationalPart, skipTens);
            }
        }

        /// <summary>
        /// 1/n = x
        /// 999...999/n = p + x;
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetRationalLength(int n, out BigInteger ratPart, out int skipTens)
        {
            const int maxNines = 10;
            BigInteger nines = 0;
            for (int m = 1; m < maxNines; m++)
            {
                nines = nines * 10 + 9;

                //if (TestForTen(nines, n, out ratPart))
                //{
                //    skipTens = 0;
                //    return 0;
                //}

                BigInteger tens = 1;
                for (int t = 0; t < maxNines; t++)
                {
                    Console.Write(">{0} nines:{1}, tens:{2}", n, nines, tens);
                    if (TestForNine(nines, n, tens, out ratPart))
                    {
                        skipTens = t;
                        Console.WriteLine();
                        return m;
                    }
                    Console.WriteLine();
                    tens = tens * 10;
                }


            }

            ratPart = new BigInteger(-1);
            skipTens = 0;
            return -1;
        }

        static bool TestForNine(BigInteger nines, int n, BigInteger skipTens, out BigInteger ratPart)
        {
            BigInteger num = skipTens * n;
            Console.Write(" num={0}, div_rest={0}!", num, nines % num);
            if (nines % num == 0)
            {
                ratPart = BigInteger.One * (nines + 1) / num;
                return true;
            }
            ratPart = BigInteger.Zero;
            return false;
        }

        static bool TestForTen(BigInteger nines, int n, out BigInteger ratPart)
        {
            BigInteger tens = nines + 1;

            if (tens % n == 0)
            {
                ratPart = BigInteger.One * tens / n;
                return true;
            }
            ratPart = BigInteger.Zero;
            return false;
        }
    }
}
