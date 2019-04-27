using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task019
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = FillCalendar(1900, 2001);
            int countSun = 0;
            foreach(var el in cl)
            {
                bool isSun = el.Value - (el.Value / 7 * 7) == 6 ? true : false;
                if (isSun && (el.Key > 190100))
                    countSun++;

                Console.WriteLine($"{el.Key,6} - {el.Value,6} : {isSun}");
            }
            Console.WriteLine("-------------");
            Console.WriteLine($"count mondays: {countSun}");
        }

        static SortedDictionary<int, int> FillCalendar(int fromYear, int ToYear)
        {
            SortedDictionary<int, int> cl = new SortedDictionary<int, int>();
            int prevDays = 0;

            for (int yr = fromYear; yr<ToYear; yr++)
            {
                for (int mn = 1; mn<=12; mn++)
                {
                    int n = yr * 100 + mn;
                    int days = prevDays + DaysInMonth(yr, mn);
                    prevDays = days;
                    cl.Add(n, days);
                }
            }

            return cl;
        }

        static bool IsFirstDayMonday(int year, int month)
        {
            return false;
        }

        static int DaysInMonth(int year, int month)
        {
            int res = 0;

            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    res = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    res = 30;
                    break;
                case 2:
                    res = DaysInFeb(year);
                    break;
                default:
                    throw new ArgumentException("month is out of range 1-12");
            }

            return res;
        }

        static int DaysInFeb(int year)
        {
            int mod4 = year - (year / 4 * 4);
            int mod400 = year - (year / 400 * 400);
            int mod100 = year - (year / 100 * 100);

            if (mod4 == 0 && (
                (mod100 != 0) ||
                (mod100 == 0 && mod400 == 0)
                ))
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
    }
}
