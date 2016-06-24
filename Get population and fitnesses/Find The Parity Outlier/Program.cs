using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_The_Parity_Outlier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] exampleTest1 = { int.MaxValue, 0, 1 };
            Console.WriteLine(Find(exampleTest1));
            Console.Read();
        }

        public static int Find(int[] integers)
        {
            int evens = 0, odds = 0, lasteven = 0, lastodd = 0;

            foreach(int vl in integers)
            {
                if ((vl & 1) == 0)
                {
                    odds++;
                    lastodd = vl;
                }
                else
                {
                    evens++;
                    lasteven = vl;
                }

                if (odds > 1 && evens > 0)
                    return lasteven;
                else if (evens > 1 && odds > 0)
                    return lastodd;

            }

            return -1;
        }
    }
}
