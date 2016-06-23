using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_odd_numbers_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(rowSumOddNumbers(42));
            Console.Read();
        }

        public static long rowSumOddNumbers(long n)
        {
            // TODO
            //get fib
            long numbers = 1;
            for (int i = 1; i < n; i++)
            {
                numbers += i;
            }

            numbers =  numbers * 2 - 1;
            long previous = numbers;

            for (int i = 1;i < n; i++)
            {
                previous += 2;
                numbers += previous;
            }

            return numbers;
            
        }

        
    }
}
