using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task011
{
    class Program
    {
        static void Main(string[] args)
        {
            string srcData = @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

            // 1. parse string into arrays
            var res = srcData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<List<int>> ar = new List<List<int>>();
            Console.WriteLine($"Len: {res.Length}");

            foreach (string ln in res)
            {
                List<int> ar1 = ln.Split(new string[] { " " }, StringSplitOptions.None)
                    .Select(t => int.Parse(t)).ToList<int>();
                ar.Add(ar1);
            }

            int lineNum = 1;
            foreach (List<int> ln in ar)
            {
                Console.Write($"{lineNum,2}. ");
                foreach(int itm in ln)
                {
                    Console.Write($"{itm,3}");
                }
                Console.WriteLine();
                lineNum++;
            }

            int maxProduct = 0;
            int maxProductIndex = 0;
            List<int> maxProductLine = null;
            
            // 2. search 4s by lines;
            foreach(List<int> ln in ar)
            {
                int maxIndexInLine = 0;
                int maxInLine = findMax4ProductInList(ln, out maxIndexInLine);

                if (maxInLine > maxProduct)
                {
                    maxProduct = maxInLine;
                    maxProductIndex = maxIndexInLine;
                    maxProductLine = ln;
                }
            }

            Console.WriteLine("1. Search in rows.");
            ShowResultForLine(maxProductLine, maxProductIndex, maxProduct);

            maxProduct = 0;
            maxProductIndex = 0;
            maxProductLine = null;
            
            // 3. search 4s by columns
            for(int col = 0; col < ar[0].Count; col++)
            {
                var ln = new List<int>();
                for (int row = 0; row < ar.Count; row++)
                {
                    ln.Add(ar[row][col]);
                }

                int maxIndexInLine = 0;
                int maxInLine = findMax4ProductInList(ln, out maxIndexInLine);

                if (maxInLine > maxProduct)
                {
                    maxProduct = maxInLine;
                    maxProductIndex = maxIndexInLine;
                    maxProductLine = ln;
                }
            }

            Console.WriteLine("2. Search in columns.");
            ShowResultForLine(maxProductLine, maxProductIndex, maxProduct);

            // 4. search by diagonal from left to right
            maxProduct = 0;
            maxProductIndex = 0;
            maxProductLine = null;

            int Ncol = ar[0].Count;
            int Nrow = ar.Count;
            for (int startCol = -Ncol + 1; startCol < Ncol; startCol++)
            {
                var ln = new List<int>();
                for (int row = 0; row < Nrow; row++)
                {
                    int col = startCol + row;
                    if (col >=0 && col < Ncol)
                        ln.Add(ar[row][col]);
                }
                // show line
                Console.Write($"StartCol: {startCol,2}. Line: ");
                foreach (int num in ln)
                {
                    Console.Write($"{num,3}");
                }
                Console.WriteLine();

                int maxIndexInLine = 0;
                int maxInLine = findMax4ProductInList(ln, out maxIndexInLine);

                if (maxInLine > maxProduct)
                {
                    maxProduct = maxInLine;
                    maxProductIndex = maxIndexInLine;
                    maxProductLine = ln;
                }
            }

            Console.WriteLine("3. Search in diagonal from left to right.");
            ShowResultForLine(maxProductLine, maxProductIndex, maxProduct);

            // 5. search by diagonal from right to left
            maxProduct = 0;
            maxProductIndex = 0;
            maxProductLine = null;

            for (int startCol = 0; startCol < Ncol*2; startCol++)
            {
                var ln = new List<int>();
                for (int row = 0; row<Nrow; row++)
                {
                    int col = startCol - row;
                    if (col >= 0 && col < Ncol)
                        ln.Add(ar[row][col]);
                }
                // show line
                Console.Write($"StartCol: {startCol,2}. Line: ");
                foreach (int num in ln)
                {
                    Console.Write($"{num,3}");
                }
                Console.WriteLine();

                int maxIndexInLine = 0;
                int maxInLine = findMax4ProductInList(ln, out maxIndexInLine);

                if (maxInLine > maxProduct)
                {
                    maxProduct = maxInLine;
                    maxProductIndex = maxIndexInLine;
                    maxProductLine = ln;
                }
            }

            Console.WriteLine("4. Search in diagonal from right to left.");
            ShowResultForLine(maxProductLine, maxProductIndex, maxProduct);

        }



        /// <summary>
        /// Show result for List
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="productIndex"></param>
        /// <param name="product"></param>
        private static void ShowResultForLine(List<int> ln, int productIndex, int product)
        {
            Console.WriteLine("-- Result --");
            Console.WriteLine("Line:");
            foreach (int num in ln)
            {
                Console.Write($"{num,3}");
            }
            Console.WriteLine();
            Console.WriteLine("chain:");

            for (int i = productIndex; i < productIndex + 4; i++)
            {
                Console.Write($"{ln[i],3}");
            }
            Console.WriteLine();

            Console.WriteLine($"start index: {productIndex + 1}, product: {product}");

        }
        
        /// <summary>
        /// Поиск произведения из 4-х последовательных чисел в списке
        /// </summary>
        /// <param name="ln">список</param>
        /// <param name="index">возвращается начало последовательности для макс произведения</param>
        /// <returns></returns>
        private static int findMax4ProductInList(List<int> ln, out int index)
        {
            int cnt = ln.Count();
            int max = 0;

            index = 0;
            if (cnt < 4)
                return 0;

            for (int i = 0; i < cnt - 3; i++)
            {
                int prod = ln[i] * ln[i + 1] * ln[i + 2] * ln[i + 3];
                if (prod > max)
                {
                    max = prod;
                    index = i;
                }
            }

            return max;
        }
    }
}
