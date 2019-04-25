using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task014
{
    class Program
    {
        static SortedDictionary<long, long> cache = new SortedDictionary<long, long>();

        static void Main(string[] args)
        {
            const long N = 1000000;
            long maxI = 0;
            long maxValue = 0;
            for (int i = 1; i < N; i++)
            {
                long res = GetChainLength(i);
                //long res = TestChain(i);
                if (res > maxValue)
                {
                    maxValue = res;
                    maxI = i; 
                }

                cache.Add(i, res);
                //Console.WriteLine($"{i}. num = {res}");
            }
            Console.WriteLine($"maxValue: {maxValue}, maxI = {maxI}");
            //ShowCache();
        }

        static long GetChainLength(long N)
        {
            long iter = 0;
            while (N > 1)
            {
                if (cache.ContainsKey(N))
                {
                    //Console.Write($"cache({N})=>");
                    //Console.Write($"{cache[N]}.");
                    iter += cache[N];
                    //Console.WriteLine();
                    return iter;
                }
                else
                {
                    iter++;
                    //Console.Write($"{N}->");
                    N = GetNextNumber(N);
                }
            }
            //Console.WriteLine($"{N}.");
            //Console.WriteLine();
            iter++;
            return iter;
        }

        static long GetNextNumber(long n)
        {
            if ((n & 1) == 0)
            {
                return n / 2;
            }
            else
            {
                return 3 * n + 1;
            }
        }

        static void ShowCache()
        {
            long i = 0;
            foreach(var t in cache)
            {
                Console.Write($"{t.Key,3}-{t.Value,3} ");
                i++;
                if (i % 10 == 0)
                    Console.WriteLine();
            }
        }

        static long TestChain(long N)
        {
            long iter = 0;
            while(N>1)
            {
                //Console.Write($"{N}->");

                iter++;
                N = GetNextNumber(N);
            }

            iter++;
            //Console.WriteLine($"{N}.");
            return iter;
        }

    }
}
