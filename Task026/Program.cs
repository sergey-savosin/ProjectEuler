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
        static int N = 1000;
        static int maxNumOfDigits = 10;
        static int maxNines = 1000;

        static void Main(string[] args)
        {
            for (int n=2; n<N; n++)
            {
                BigInteger rationalPart;
                int skipWholeDigits, numSkipDigits;
                int ratLength = GetRationalLength(n, out rationalPart, out skipWholeDigits, out numSkipDigits);
                Console.WriteLine("{0}. skipWhole: {1}({2}); ratPart: {3}({4})", n,
                    skipWholeDigits, numSkipDigits,
                    rationalPart, ratLength);
            }
        }

        /// <summary>
        /// 1/n = x
        /// 999...999/n = p + x;
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetRationalLength(int n, out BigInteger ratPart, out int skipWholeDigits, out int numSkipDigits)
        {
            int wholeDigits = 0;
            BigInteger wholeTens = 1;
            BigInteger nines = 0;
            for (int numOfDigits = 0; numOfDigits <= maxNumOfDigits; numOfDigits++)
            {
                wholeDigits = GetWholeDigits(n, wholeTens);
                nines = 0;

                for (int m = 1; m < maxNines; m++)
                {
                    nines = nines * 10 + 9;

                    if (TestForTen(nines, n, out ratPart))
                    {
                        skipWholeDigits = 0;
                        numSkipDigits = 0;
                        return 0;
                    }

                    //Console.Write("[whole: {0}={1}] ", numOfDigits, wholeDigits);
                    //Console.Write(">{0} nines:{1}, tens:{2}", n, nines, wholeTens);
                    if (TestForNine(nines, n, wholeTens, wholeDigits, out ratPart))
                    {
                        //Console.WriteLine();
                        skipWholeDigits = wholeDigits;
                        numSkipDigits = numOfDigits;
                        return m;
                    }
                    //Console.WriteLine();

                }

                wholeTens = wholeTens * 10;
            }

            ratPart = new BigInteger(-1);
            skipWholeDigits = 0;
            numSkipDigits = 0;
            return -1;
        }

        private static int GetWholeDigits(int n, BigInteger wholeTens)
        {
            return (int)(wholeTens / n);
        }

        static bool TestForNine(BigInteger nines, int n, BigInteger wholeTens, int wholeDigits, out BigInteger ratPart)
        {
            BigInteger num = nines * (wholeTens - wholeDigits * n);
            //Console.Write(" num={0}, div_rest={0}!", num, nines % n);
            if (num % n == 0)
            {
                ratPart = BigInteger.One * num / n;
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
