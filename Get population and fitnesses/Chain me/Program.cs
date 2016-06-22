using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_me
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public static double Chain(double input, Func<double, double>[] fs)
        {
            // your code ...
            //foreach (Func<double, double> f in fs)
            //{
            //    input = f(input);
            //}
            //return input;


            return fs.Aggregate(input, (current, t) => t(current));
        }
    }
}
