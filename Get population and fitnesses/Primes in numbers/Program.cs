using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes_in_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lst = 7775460;
            Console.WriteLine(factors(lst));
            Console.Read();
        }



        public static String factors(int lst)
        {
            //List<int> primes = getPrimeNumbers(lst);
            List<int> primes = GeneratePrimes(lst);

            Dictionary<int, int> D = new Dictionary<int, int>();
            StringBuilder st = new StringBuilder();

            getFactors(lst, D, primes);
            
            foreach(KeyValuePair<int, int> kv in D)
            {
                st.Append(string.Format("({0}{1})", kv.Key, kv.Value > 1 ? "**" + kv.Value : ""));
            }

            return st.ToString();
        }

        static void getFactors(int n, Dictionary<int, int> D, List<int> primes)
        {
            while (n > 1)
            {
                foreach (int vl in primes)
                {
                    if (n % vl == 0)
                    {
                        if (!D.ContainsKey(vl))
                            D[vl] = 0;

                        D[vl]++;
                        n /= vl;
                        break;
                    }
                }
            }
        }

        //static int nextPrimeNumber(int n, List<int> primes)
        //{
        //    int res = primes.FirstOrDefault(x => x > n);

        //    if(res == 0)
        //    {
        //        while(true )
        //        {
        //            n += 2;
        //            if (isPrime(n, primes))
        //                break;
        //        }
        //        res = n;
        //        primes.Add(res);
        //    }

            
        //    return res;
        //}

        //static bool isPrime(int n, List<int> primes)
        //{
        //    if (n == 2)
        //        return true;

        //    int sq = (int)Math.Sqrt(n);

        //    var lw = primes.Where(x => x <= sq);

        //    foreach(int vl in lw)
        //    {
        //        if (n % vl == 0)
        //            return false;
        //    }

            
        //    return true;
        //}

        static List<int> getPrimeNumbers(int n)
        {
            List<int> res = new List<int>();

            bool[] primes = new bool[n+1];

            double sqr = Math.Sqrt(n);
            for (int i = 2; i <= sqr; i++) 
            {
                if(primes[i] == false)
                for (int j = i + i; j <= n; j += i)
                    primes[j] = true;
            }

            for(int i = 2; i <= n; i++)
            {
                if (! primes[i])
                    res.Add(i);
            }

            return res;

        }

        static List<int> GeneratePrimes(int n)
        {
            var r = from i in Enumerable.Range(2, n - 1).AsParallel()
                    where Enumerable.Range(2, (int)Math.Sqrt(i)).All(j => i % j != 0)
                    select i;
            return r.ToList();
        }

    }
}
