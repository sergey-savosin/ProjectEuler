using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task012
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 13000;
            int tnum = 0;
            int maxDivs = 0;
            Console.WriteLine("test: {0}", 15- (15 / 7*7));
            for (int i=0; i<N; i++)
            {
                tnum += i;
                int divs = FindNumberOfDivisors(tnum);
                if (divs > maxDivs)
                {
                    maxDivs = divs;
                    Console.WriteLine($"{i,3}. num: {tnum}, divs: {divs}");
                }
                if (i % 100 == 0)
                    Console.Write($"<{i}:{tnum}>.");
            }
        }

        static int FindNumberOfDivisors(int num)
        {
            int res = 1; //1
            for(int i=2; i<(num/2+1); i++)
            {
                if ((num - (num/i*i)) == 0)
                {
                    res++;
                    //Console.Write($"{i,3}");
                }
            }
            //Console.WriteLine($"");

            return res;
        }
    }
}
