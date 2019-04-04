using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task007
{
    class Program
    {
        public const int N = 1000000;//110000000;

        static void Main(string[] args)
        {
            Console.WriteLine("start");
            Primes p = new Primes(N);
            p.ShowAllPrimes(totalOnly: true);
            int p10001 = p.GetPrimeNumber(10001 - 1);
            Console.WriteLine("p10001 = {0}", p10001);

            //p.TestMergeExpansion(345, 5436);
            //p.TestSqrExpansion(345);
            p.DoSpecialExpansion(123, 456, N);

            //        for (int i=110000000-90; i<110000001; i++)
            //            p.ShowExpansion(i);
            Console.WriteLine(" < -- press any key -- >");
            Console.ReadLine();
        }
    }
}
