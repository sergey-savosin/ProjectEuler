using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task008
{
    class Program
    {
        static void Main(string[] args)
        {
            string srcStr = @"73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450";
            string subStr = "";
            const int N = 13;
            SortedDictionary<string, long> dict = new SortedDictionary<string, long>();
            SortedDictionary<long, string> dictNum = new SortedDictionary<long, string>();

            srcStr = srcStr.Replace("\r", "");
            srcStr = srcStr.Replace("\n", "");
            for (int i = 0; i < (srcStr.Length - (N-1)); i++)
            {
                subStr = srcStr.Substring(i, N);
                if (TestTwoNines(subStr, N))
                {
                    long val = GetValue(subStr, N);
                    if (!dict.ContainsKey(subStr))
                    {
                        dict.Add(subStr, val);
                        //Console.Write($"{i,4}+ {subStr,N+1}");
                    }
                    else
                    {
                        //Console.Write($"{i,4}- {subStr,N+1}");
                    }

                    if (!dictNum.ContainsKey(val))
                        dictNum.Add(val, subStr);
                }
                else
                {
                    //Console.Write($"{i,4}. {subStr,N+1}");
                }

                //if ((i+1) % (1) == 0)
                //    Console.WriteLine();
            }

            int k = 0;
            
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("-- Dictionary list: --");
            //foreach (var el in dict)
            //{
            //    Console.Write($"{el.Key,5} - {el.Value,N+1}");
            //    k++;
            //    if (k % 1 == 0)
            //        Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-- First 15 top values --");
            var ans = dict.OrderByDescending(d => d.Value)
                .Take(15)
                .Select(d => new { d.Key, d.Value })
                ;
            k = 0;
            foreach (var a in ans)
            {
                k++;
                Console.Write($"{k,3}. {a.Key,5} - {a.Value,N+1}");
                if (k % 1 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("-- First 15 unique values --");
            k = 0;
            foreach(var el in dictNum.OrderByDescending(d => d.Key).Take(15))
            {
                k++;
                Console.Write($"{k,3}. {el.Key,5}");
                if (k % 5 == 0)
                    Console.WriteLine();
            }
                
        }

        private static long GetValue(string subStr, int N)
        {
            Debug.Assert(subStr.Length == N);
            long res = 1;
            for (int i = 0; i < N; i++)
                res *= long.Parse(subStr[i].ToString());

            return res;
        }

        static bool TestTwoNines(string str, int N)
        {
            if (str.Contains("0"))
                return false;
            else
                return true;
        }
    }
}
