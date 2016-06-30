using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Going_to_zero_or_to_infinity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(going(6));

            Console.Read();
        }

        //public static double going(int n)
        //{
        //    Dictionary<int, ulong> D = new Dictionary<int, ulong>();

        //    ulong sumFactorial = 0;

        //    for(int i = 1; i <= n; i++)
        //    {
        //        sumFactorial += factorial(i, D);
        //    }

        //    decimal div = decimal.Divide(1, factorial(n,D));

        //    decimal res = decimal.Multiply(div, sumFactorial);

        //    return (double)Math.Round(res, 6);
        //}

        //static ulong factorial(int n, Dictionary<int, ulong> D)
        //{
        //    ulong res = 0;

        //    if (D.ContainsKey(n))
        //        return D[n];

        //    if (n < 2)
        //        res = 1;
        //    else
        //        res = factorial(n - 1, D) * (ulong)n;

        //    return D[n] = res;

        //}

        public static double going(int n)
        {
            Dictionary<int, BigInteger> D = new Dictionary<int, BigInteger>();

            

            BigInteger sumFactorial = 0;
            

            for (int i = 1; i <= n; i++)
            {
                sumFactorial += factorial(i, D);
            }

            double div = Math.Exp(BigInteger.Log(1) - BigInteger.Log(D[n]));
            //double div = 1 / D[n];

            BigInteger res = (BigInteger)div * sumFactorial;

            return 0;//Math.Round(res, 6);
        }

        //static double factorial(int n, Dictionary<int, double> D)
        //{
        //    double res = 0;

        //    if (D.ContainsKey(n))
        //        return D[n];

        //    if (n < 2)
        //        res = 1;
        //    else
        //        res = factorial(n - 1, D) * n;

        //    return D[n] = res;

        //}

        static BigInteger factorial(int n, Dictionary<int, BigInteger> D)
        {
            BigInteger res = 0;

            if (D.ContainsKey(n))
                return D[n];

            if (n < 2)
                res = 1;
            else
                res = factorial(n - 1, D) * n;

            return D[n] = res;

        }
    }
}
