using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task018
{
    class Program
    {
        static void Main(string[] args)
        {
            //const int N = 4;
            //int[,] a = new int[N,N];
            //a[0, 0] = 3;
            //a[1, 0] = 7;
            //a[1, 1] = 4;
            //a[2, 0] = 2;
            //a[2, 1] = 4;
            //a[2, 2] = 6;
            //a[3, 0] = 8;
            //a[3, 1] = 5;
            //a[3, 2] = 9;
            //a[3, 3] = 3;

            int [,] a = Read2dArrayFromTextFile("p067_triangle.txt");

            printArray2d(a);
            Console.WriteLine("------------");
            int[,] b = buildWorkArray(a);
            printArray2d(b);
            Console.WriteLine("------------");
            int iMax = findMaxInLastLine(b);
            Console.WriteLine($"max: {iMax}");
        }

        private static int findMaxInLastLine(int[,] b)
        {
            int N = b.GetLength(0);
            int nMax = 0;
            for (int i=0; i<N; i++)
            {
                int val = b[N - 1, i];
                if (nMax < val)
                    nMax = val;
            }

            return nMax;
        }

        private static int[,] Read2dArrayFromTextFile(string filename)
        {
            List<string> strs = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine())!= null)
                {
                    strs.Add(line);
                }
            }

            int N = strs.Count();
            int[,] a = new int[N, N];

            for (int i = 0; i<N; i++)
            {
                string ln = strs[i];
                List<int> nums = ln.Split(new string[] { " " }, StringSplitOptions.None)
                    .Select(t => int.Parse(t))
                    .ToList<int>();

                int col = 0;
                foreach (int n in nums)
                {
                    a[i, col] = n;
                    col++;
                }
            }

            return a;
        }

        static void printArray2d(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j],5}");
                }
                Console.WriteLine();
            }

        }

        static int[,] buildWorkArray(int[,] a)
        {
            int N = a.GetLength(0);
            int[,] b = new int[N,N];

            for (int i=0; i<N; i++)
            {
                if (i==0)
                {
                    b[i, 0] = a[i, 0];
                }
                else
                {
                    for (int j=0;j<=i;j++)
                    {
                        if (j==0)
                        {
                            // left cell
                            b[i, j] = b[i - 1, j] + a[i, j];
                        }
                        else if (j==i)
                        {
                            // right cell
                            b[i, j] = b[i - 1, j - 1] + a[i, j];
                        }
                        else
                        {
                            // middle cell
                            int t = Math.Max(b[i - 1, j - 1], b[i - 1, j]);
                            b[i, j] = t + a[i, j];
                        }
                    }
                }
                

            }

            return b;
        }
    }
}
