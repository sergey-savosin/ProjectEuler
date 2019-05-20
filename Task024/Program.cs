using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task024
{
    class Program
    {
        const int N = 10;
        static int counter = 0;

        static void Main(string[] args)
        {
            bool[] bMap = new bool[10];
            byte[] dMap = new byte[10];

            initBoolMap(bMap);
            setDigit(bMap, dMap, 0);
        }

        static void setDigit(bool[] bMap, byte[] dMap, int digit)
        {
            for (byte i=0; i<N; i++)
            {
                if (bMap[i] == false)
                {
                    bMap[i] = true;
                    dMap[digit] = i;
                    if (digit < N && counter < 1000000)
                        setDigit(bMap, dMap, digit + 1);

                    if (digit == (N - 1))
                    {
                        counter++;
                        showMaps(bMap, dMap);
                    }

                    bMap[i] = false;
                }
            }
        }

        static void initBoolMap(bool[] m)
        {
            for (int i=0; i<N; i++)
            {
                m[i] = false;
            }
        }

        static void showMaps(bool[] m, byte[] d)
        {
            if (!(counter % 100 == 0))
                return;

            Console.Write("{0}. ", counter);
            //for (int i=0; i<N; i++)
            //{
            //    Console.Write("{0,2}", m[i] ? 1 : 0);
            //}

            //Console.Write(" -> ");

            for (int i=0; i<N; i++)
            {
                Console.Write("{0,1}", d[i]);
            }

            Console.WriteLine();
        }
    }
}
