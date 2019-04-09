using System;
using System.Collections.Generic;
using System.Text;

public class Primes
{
    List<int> primes;

    public Primes(int N)
    {
        List<bool> src = new List<bool>();
        int i, iMax, k;

        iMax = (int)Math.Floor(Math.Sqrt(N));
        // init src array
        for (i = 0; i <= N; i++)
        {
            src.Add(true);
        }

        //eratosphen
        src[0] = false;
        src[1] = false;
        i = 2;
        while (i <= N)
        {
            src[i] = true;
            for (k = i + i; k <= N; k += i)
                src[k] = false;
            i++;

            while ((i <= N) && (src[i] == false))
            {
                ++i;
            }
            if ((i <= N) && (src[i] == false))
            {
                i = N + 1; //exit
            }
        }

        // copy numbers to list
        primes = new List<int>();
        for (i = 1; i <= N; ++i)
            if (src[i] == true)
                primes.Add(i);

    }

    public int GetPrimeNumber(int i)
    {
        if (i >= primes.Count)
            return -1;
        return primes[i];
    }

    public SortedDictionary<int, int> FindExpansion(int k)
    {
        int i = 0, rest = k, cnt = 0;
        SortedDictionary<int, int> res = new SortedDictionary<int, int>();
        while (rest > 1)
        {
            if ((rest % primes[i]) == 0)
            {
                cnt++;
                rest = rest / primes[i];
            }
            else
            {
                if (cnt > 0)
                    res[primes[i]] = cnt;
                i++;
                cnt = 0;
            }
        }
        if (cnt > 0)
            res[primes[i]] = cnt;

        return res;
    }

    // объединить два разложения в одно
    public SortedDictionary<int, int> MergeExpansions(SortedDictionary<int, int> a, SortedDictionary<int, int> b)
    {
        SortedDictionary<int, int> res = new SortedDictionary<int, int>();
        foreach (KeyValuePair<int, int> p in a)
        {
            res[p.Key] = p.Value;
        }
        foreach (KeyValuePair<int, int> p in b)
        {
            if (res.ContainsKey(p.Key))
            {
                res[p.Key] = res[p.Key] + p.Value;
            }
            else
            {
                res[p.Key] = p.Value;
            }
        }
        return res;
    }

    // увеличить степени разложения вдвое
		public SortedDictionary<int, int> SqrExpansion(SortedDictionary<int, int> a)
		{
			var res = new SortedDictionary<int, int>();
			foreach (KeyValuePair<int, int> p in a)
			{
				res[p.Key] = p.Value * 2;
			}

			return res;
		}

    public void ShowAllPrimes(bool totalOnly)
    {
        StringBuilder sb = new StringBuilder();
        if (!totalOnly)
        {
            foreach (int i in primes)
                sb = sb.AppendFormat("{0} ", i);
            Console.WriteLine(sb);
        }
        Console.WriteLine("total primes count: {0}", primes.Count);
    }

    public long GetSumOfPrimesNoMoreThan(int N)
    {
        long res = 0;
        foreach (var p in primes)
        {
            if (p <= 2000000)
                res += p;
        }
        return res;
    }

    public void ShowDictionaryInt2(SortedDictionary<int, int> d)
    {
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<int, int> p in d)
        {
            sb = sb.AppendFormat("{0}^{1} ", p.Key, p.Value);
        }
        Console.WriteLine(sb);
    }

    public void ShowExpansion(int k)
    {
        SortedDictionary<int, int> res;
        res = FindExpansion(k);
        Console.WriteLine("---- expansion of {0}: ----", k);
        ShowDictionaryInt2(res);
    }

    public void TestMergeExpansion(int a, int b)
    {
        SortedDictionary<int, int> a_exp;
        SortedDictionary<int, int> b_exp;
        a_exp = FindExpansion(a);
        Console.WriteLine("a: {0} expands to", a);
        ShowDictionaryInt2(a_exp);
        b_exp = FindExpansion(b);
        Console.WriteLine("b: {0} expands to", b);
        ShowDictionaryInt2(b_exp);
        a_exp = MergeExpansions(a_exp, b_exp);
        Console.WriteLine("merge expands to");
        ShowDictionaryInt2(a_exp);
    }

    public void TestSqrExpansion(int a)
    {
    	SortedDictionary<int, int> a_exp;
    	
    	a_exp = FindExpansion(a);
    	Console.WriteLine("a: {0} expands to", a);
    	ShowDictionaryInt2(a_exp);

    	a_exp = SqrExpansion(a_exp);
    	Console.WriteLine("sqr expansion of a:");
    	ShowDictionaryInt2(a_exp);

    	a_exp = FindExpansion(a*a);
    	Console.WriteLine("a*a: {0} expands to", a*a);
    	ShowDictionaryInt2(a_exp);
    }

    public void DoSpecialExpansion(int a, int b, int maxsum)
    {
    	SortedDictionary<int, int> a_exp;
    	SortedDictionary<int, int> b_exp;
    	SortedDictionary<int, int> mrg;
    	a_exp = FindExpansion(a);
    	b_exp = FindExpansion(b);
    	b_exp = SqrExpansion(b_exp);
    	mrg = MergeExpansions(a_exp, b_exp);
    	Console.WriteLine("a: {0}, b: {1}. Special expand:", a, b);
    	ShowDictionaryInt2(mrg);
    }
}
