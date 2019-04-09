using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task009
{
    class Program
    {
        static void Main(string[] args)
        {
            const long NumMax = 500;
            long a = 0;
            long a2 = 0;
            long a2prev = 0;

            long b = 0;
            long b2 = 0;

            long c = 0;
            long c2 = 0;

            long delta = 0;
            bool isFound = false;

            for (long i=1; i<=NumMax; i++)
            {
                a2prev = a2;
                // Новые значения a, a2
                a++;
                a2 = a2prev + 2*a -1;
                Console.WriteLine($"-- {a,3}. a2 prev: {a2prev,11}, a2: {a2,11} --");

                b = a;
                b2 = a2prev;
                for (long j = i; j <= NumMax; j++)
                {
                    // Новые значения для b, b2
                    b2 = b2 + 2*b - 1;

                    // Вычисление значений для c, c2
                    c = 1000 - a - b;
                    c2 = c * c;

                    // Проверка критерия Триплетов Пифагора

                    delta = c2 - a2 - b2;
                    if (delta == 0)
                    {
                        Console.WriteLine("*********** Triplet found.***************");
                        Console.WriteLine($"a: {a}, b: {b}, c: {c}, a2: {a2}, b2: {b2}, c2: {c2}");
                        isFound = true;
                        break;
                    }
                    else
                    {
                        if (delta < 100 && delta > -100)
                            Console.WriteLine($"a: {a}, b: {b}, c: {c}, a2: {a2}, b2: {b2}, c2: {c2}, delta: {delta}");
                    }

                    b++;
                }

                if (isFound)
                    break;
            }
        }
    }
}
