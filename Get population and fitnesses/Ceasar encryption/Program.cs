using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar_encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<char, char> D = new Dictionary<char, char>();
            //Enumerable.Range(65, 59).ToList().ForEach(x => Console.Write(" ({1}-{0})", shiftChar(-6, (char)x, D), (char)x));
            //Console.Write(" {0}-{1}", shiftChar(2, 'z'), 'a'- 'z');
            //string u = "I should Have known that you would have a perfect answer for me!!!";
            //string u = "O CAPTAIN! my Captain! our fearful trip is done;";
            //string u = "aAgGzZ";

            //int shift = 27;//(1+26*1) * -1;
            //List<string> s = encodeStr(u, shift);

            //foreach (string st in s)
            //    Console.Write("," + st);

            //Console.WriteLine("\n solution");
            //Console.WriteLine(decode(s));

            Console.WriteLine("{0}-{1}, ", split(17, 5), 17);
            Enumerable.Range(5,100).ToList().ForEach(x => Console.WriteLine("{0}-{1}, ",split(x, 5), x));

            Console.Read();
        }

        public static List<string> encodeStr(string s, int shift)
        {
            //for memoization
            Dictionary<char, char> D = new Dictionary<char, char>();

            List<string> res = new List<string>();

            char[] resc = new char[s.Length + 2];
            resc[0] = char.ToLower(s[0]);
            resc[1] = shiftChar(shift, resc[0], D);

            int counter = 2;
            foreach(char c in s)
            {
                resc[counter++] = shiftChar(shift, c, D);
            }

            int runners = 5;
            int pieces = split(resc.Length, runners);

            string st = new string(resc);

            for (int i = 0; i < st.Length; i+=pieces)
            {
                res.Add(st.Substring(i, i + pieces >= resc.Length ? resc.Length - i: pieces));
            }

            return res;
        }

        public static string decode(List<string> s)
        {
            Dictionary<char, char> D = new Dictionary<char, char>();

            string st = string.Concat(s);

            int shift = calculateShift(st[0], st[1]);

            StringBuilder sb = new StringBuilder();

            for(int i = 2; i < st.Length; i++)
            {
                sb.Append(shiftChar(-shift, st[i], D));
            }

            return sb.ToString();
        }

        static int calculateShift(char c1, char c2)
        {
            int alphabet = 26;

            char c2l = char.ToLower(c2);

            int res = c2l - c1;

            if (char.IsUpper(c2))
            {
                res += alphabet;
            }

            return res;
        }

        static int split(int size, int parts)
        {
            int res = size / parts;
            int mod = size % parts;

            if(mod != 0)
            {
                res = size / (parts - 1);
                
                int maxMod = -1;
                
                while(true)
                {
                    if (res == 0)
                        return res + 1;

                    mod = size % res;

                    if (size / res > parts - 1)
                    {
                        return res + 1;
                    }

                    if(mod <= maxMod)
                    {
                        return res + 1;
                    }
                    maxMod = mod;
                    res--;
                }
            }
            return res;
        }
        
        static char shiftChar(int shift, char c, Dictionary<char, char> D)
        {
            if (!char.IsLetter(c))
                return c;

            if (D.ContainsKey(c))
                return D[c];

            int alphabet = 26;
            int mod = 0;
            int times = 0;

            if (shift < 0)
            {
                times = shift / (alphabet * 2);
                shift = (shift  % (alphabet *2)) + (alphabet * 2);
                
            }

            int res = c + shift;

            if (char.IsUpper(c))
                res -= 'A';
            else
                res -= 'a';

            mod = res % (alphabet);
            times += res / (alphabet);

            if ((times & 1) == 1)
            {
                if (char.IsUpper(c))
                    res = mod + 'a';
                else
                    res = mod + 'A';
            }
            else
            {
                if (char.IsUpper(c))
                    res = mod + 'A';
                else
                    res = mod + 'a';
            }
            
            return D[c] = (char)res;
            
        }
    }
}
