using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task021
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Nmax = 10000;

            int total = 0;

            for (int i = 1; i<Nmax; i++)
            {
                if (CheckAndTake(i))
                {
                    total += i;
                    Console.WriteLine($"{i,5}");
                }
            }

            Console.WriteLine($"total: {total}");
        }

        static bool CheckAndTake(int N)
        {
            int sum = D(N);
            int sum2 = D(sum);
            if (sum2 == N && sum2 != sum)
                return true;
            else
                return false;
        }

        static int D(int N)
        {
            int sum = 0;
            for (int i = 1; i<=N/2; i++)
            {
                if (N - N/i*i == 0)
                {
                    sum += i;
                    //Console.Write($"{i,5}");
                }
            }
            //Console.WriteLine($"sum: {sum,5}");

            return sum;
        }
    }
}
