using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task018
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 4;
            int[,] a = new int[N,N];
            a[0, 0] = 3;
            a[1, 0] = 7;
            a[1, 1] = 4;
            a[2, 0] = 2;
            a[2, 1] = 4;
            a[2, 2] = 6;
            a[3, 0] = 8;
            a[3, 1] = 5;
            a[3, 2] = 9;
            a[3, 3] = 3;

            printArray2d(a);
            Console.WriteLine("------------");
            findAllPaths(a);
        }

        static void printArray2d(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j],3}");
                }
                Console.WriteLine();
            }

        }

        static void findAllPaths(int[,] a)
        {
            int N = a.GetLength(0);
            ShowNode(a, 0, 0);
            Console.WriteLine();

            ProcessNode(a, 0, 0, N);
        }

        static void ProcessNode(int[,] a, int i, int j, int N)
        {
            if (i >= N-1)
                return;

            ShowNode(a, i + 1, j);
            ShowNode(a, i + 1, j + 1);
            Console.WriteLine();

            ProcessNode(a, i + 1, j, N);
            ProcessNode(a, i + 1, j + 1, N);
        }

        static void ShowNode(int[,] a, int i, int j)
        {
            Console.Write($"{a[i, j], 3}");
        }
    }
}
