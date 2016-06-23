using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_number_3r
{
    class Program
    {
        static void Main(string[] args)
        {
            int lst = int.MaxValue;
            Console.WriteLine(factors(lst));
            Console.Read();
        }


        public static String factors(int lst)
        {
            Dictionary<int, int> D = new Dictionary<int, int>();
            StringBuilder st = new StringBuilder();

            while (lst % 2 == 0)
            {
                if (!D.ContainsKey(2))
                    D[2] = 0;
                D[2]++;
                lst = lst / 2;
            }

            for (int i = 3; i <= Math.Sqrt(lst); i = i + 2)
            {
                while (lst % i == 0)
                {
                    if (!D.ContainsKey(i))
                        D[i] = 0;
                    D[i]++;

                    lst = lst / i;
                }
            }

            if (lst > 2)
            {
                if (!D.ContainsKey(lst))
                    D[lst] = 0;
                D[lst]++;
            }

            foreach (KeyValuePair<int, int> kv in D)
            {
                st.Append(string.Format("({0}{1})", kv.Key, kv.Value > 1 ? "**" + kv.Value : ""));
            }

            return st.ToString();
        }
    }
}
