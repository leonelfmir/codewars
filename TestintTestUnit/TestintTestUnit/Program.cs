using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestintTestUnit
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class ChromosomeWrap
    {
        public string Chromosome { get; set; }
        public double Fitness { get; set; }
    }
    public class Kata
    {
        public IEnumerable<ChromosomeWrap> MapPopulationFit(IEnumerable<string> population, Func<string, double> fitness)
        {
            List<ChromosomeWrap> L = new List<ChromosomeWrap>();

            foreach(string s in population)
            {
                L.Add(new ChromosomeWrap() { Chromosome = s, Fitness = fitness(s) });
            }

            return L;
        }
    }
}
