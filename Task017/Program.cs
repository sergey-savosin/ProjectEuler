using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task017
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 1000;
            int totalLen = 0;
            for (int i = 1; i<=N; i++)
            {
                string str = WriteANumber(i);
                totalLen += str.Replace(" ", "").Length;

                Console.WriteLine($"{i,2}. {str}");
            }

            Console.WriteLine($"total length: {totalLen}.");
        }

        private static string WriteANumber(int i)
        {
            if (i < 10)
                return WriteASingleDigit(i);

            if (i < 100)
                return WriteDoubleDigit(i);

            if (i < 1000)
                return WriteTripleDigit(i);

            if (i == 1000)
                return "one thousand";

            return "";
        }

        private static string WriteASingleDigit(int i)
        {
            if (i>9)
            {
                throw new ArgumentException($"{i} is out if range 1-9.");
            }

            switch (i)
            {
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "";
            }
        }

        private static string WriteDoubleDigit(int i)
        {
            if (i<10)
            {
                return WriteASingleDigit(i);
            }

            if (i>99)
            {
                throw new ArgumentException($"{i} is out of range 1-99.");
            }

            switch (i)
            {
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                case 20: return "twenty";
                case 30: return "thirty";
                case 40: return "forty";
                case 50: return "fifty";
                case 60: return "sixty";
                case 70: return "seventy";
                case 80: return "eighty";
                case 90: return "ninety";
                default:
                    int d = i / 10 * 10;
                    return WriteDoubleDigit(d) + " " + WriteASingleDigit(i-d);
            }
        }

        private static string WriteTripleDigit(int i)
        {
            if (i < 100 || i > 999)
            {
                throw new ArgumentException($"{i} is out of range 100-999.");
            }

            int h = i / 100;
            int dd = i - h * 100;
            if ( dd == 0)
            {
                return WriteASingleDigit(h) + " hundred";
            }
            else
            {
                return WriteTripleDigit(h * 100) + " and " + WriteDoubleDigit(dd);
            }

        }
    }
}
