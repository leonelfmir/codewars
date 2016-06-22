using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette_wheel_selection
{
    class Program
    {
        static void Main(string[] args)
        {
            Kata kata = new Kata();
            string[] population = new string[] { "1", "2", "3" };
            double[] fitnesses = new double[] { 0.05, 0.05, 0.9 };

            for (int i = 0; i < 10; i++)
            {
                Console.Write(kata.Select(population, fitnesses) + " ");
            }

            Console.Read();
        }
    }

    public class Kata
    {
        static Random rn = new Random();
        public string Select(IEnumerable<string> population, IEnumerable<double> fitnesses)
        {
            List<Tuple<int, int>> roult = roulete(fitnesses);

            
            int r = rn.Next(100);

            int counter = 0;
            foreach(Tuple<int, int> vl in roult)
            {
                if (r >= vl.Item1 && r <= vl.Item2)
                    return population.ElementAt(counter);

                counter++;
            }

            return "";
        }

        private List<Tuple<int,int>> roulete(IEnumerable<double> fitnesses)
        {
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();

            int counter = 0;
            foreach (double vl in fitnesses)
            {
                int start = counter == 0 ? 0 : res[counter - 1].Item2 + 1;
                int end = start + (int)(vl * 100) - 1;
                res.Add(new Tuple<int, int>(start, end));
                counter++;
            }

            return res;
        }
    }
}
