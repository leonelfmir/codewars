using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_equals_range
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("{0} {1}",sumRange(26) - 15 - 21, 15*21);
            //Enumerable.Range(1, 500).ToList().ForEach(x => removNb(x));
            long n = 325;
            var res = removNb(n);

            var res2 = from b in res
                       orderby b[0]
                       select b; 

            foreach(long[] b in res2)
            {
                Console.WriteLine("{0}-{1} ", b[0], b[1]);
            }

            Console.Read();
        }

        public static List<long[]> removNb(long n)
        //public static bool removNb(long n)
        {
            // your code
            long rangeSum = (n * (n + 1)) / 2;
            List<long[]> res = new List<long[]>();

            long l = 1;
            long r = n;

            long sum = 0;
            long mult = 0;
            while(l < r)
            {
                sum = rangeSum - l - r;
                mult = l * r;
                if ( sum > mult)
                {
                    l++;
                }
                else if(sum < mult)
                {
                    r--;
                }
                else
                {
                    res.Add(new long[]{ l,r});
                    res.Add(new long[]{ r,l});
                    l++;
                    r--;
                }
            }

            return (from b in res
                   orderby b[0]
                   select b).ToList();

            //for (long i = 1; i < n; i++)
            //{
            //    for (long j = n; j > i; j--)
            //    {
            //        if (rangeSum - i - j == i * j)
            //        {
            //            Console.WriteLine("{0},{1} = {2}", i, j, n);

            //        }
            //    }
            //}
        }

        //static long sumRange(int end)
        //{
        //    return (end * (end + 1)) / 2;
        //}
    }
}
