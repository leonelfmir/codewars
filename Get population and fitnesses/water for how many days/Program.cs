using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace water_for_how_many_days
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write( ThirstyIn(150, new int[] { 5, 30, 10 }));
            Console.Read();
        }

        public static int ThirstyIn(int water, int[] ageOfDweller)
        {
            if (ageOfDweller.Length == 0)
                return -1;

            Dictionary<int, double> AgesConsumption = new Dictionary<int, double>();
            AgesConsumption[0] = 1;
            AgesConsumption[18] = 2;
            AgesConsumption[50] = 1.5;

            double WaterEachDay = 0;

            WaterEachDay = ageOfDweller.Sum(y => AgesConsumption[AgesConsumption.Keys.LastOrDefault(x => y >= x)]);

            //foreach(int vl in ageOfDweller)
            //{
            //    if(vl >= 0)
            //        WaterEachDay += AgesConsumption[AgesConsumption.Keys.LastOrDefault(x => vl >= x)];
            //}

            return (int)(water / WaterEachDay);
        }
    }
}
