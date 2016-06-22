using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mombling
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ZpglnRxqenU";
            s = Accumul.Accum(s);
            
            Console.WriteLine(s);
            Console.Read();
        }
    }

    public class Accumul
    {
        public static String Accum(string s)
        {
            // your code
            StringBuilder res = new StringBuilder();

            int counter = 0;
            foreach (char c in s)
            {
                if(counter > 0)
                    res.Append("-");

                res.Append(c.ToString().ToUpper());
                
                for(int i = 0; i < counter; i++)
                {
                    res.Append(c.ToString().ToLower());
                }

                
                counter++;
            }

            return res.ToString();
        }
    }
}
