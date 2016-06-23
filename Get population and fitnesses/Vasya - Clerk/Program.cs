using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasya___Clerk
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] peopleInLine = new int[] { 25, 25, 50, 50,100 };

            Console.WriteLine(Tickets(peopleInLine));
            Console.Read();
        }


        class Cashier
        {

            Dictionary<int, int> cs = new Dictionary<int, int>();
            int cost = 0;

            public Cashier(int Cost, params int[] bills)
            {
                cost = Cost;
                foreach (var b in bills)
                {
                    cs[b] = 0;
                }
            }

            public bool giveChange(int bill)
            {
                cs[bill]++;
                bill -= cost;

                int times = 0;
                int diff = 0;
                var ks = from x in cs.Keys
                         where x <= bill
                         orderby x descending
                         select x;
                         

                //foreach (int vl in cs.Keys.(x => x <= bill))
                foreach(int vl in ks)
                {
                    //getting how many bills we have to return of time vl
                    times = bill / vl;

                    //getting the bills that needs to be taken out
                    diff = Math.Min(times, cs[vl]);

                    //taking them out
                    cs[vl] -= diff;

                    //decreasing bill
                    bill -= diff * vl;
                }

                if (bill <= 0)
                    return true;

                return false;
            }
        }

        public static string Tickets(int[] peopleInLine)
        {
            //Your code is here...
            Cashier cs = new Cashier(25,25,50,100);

                foreach(int vl in peopleInLine)
                {
                    if (!cs.giveChange(vl))
                        return "NO";
                }

                return "YES";
        }
    }
}
