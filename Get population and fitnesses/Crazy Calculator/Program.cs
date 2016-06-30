using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "382/263-337-490-116/159*215/162/47/390+277";



            double res = new Kata().crazyCalculate(s);
            Console.WriteLine(res);

            Console.Read();
        }
    }

    public class Kata
    {
        public double crazyCalculate(string input)
        {
            Dictionary<char, int> Priority = new Dictionary<char, int>();
            Priority['*'] = 0;
            Priority['/'] = 0;
            Priority['+'] = 1;
            Priority['-'] = 1;

            var numbers = input.Split(Priority.Keys.ToArray());

            var s = input.Where(x => Priority.ContainsKey(x)).ToArray();

            LList LL = new LList();

            for (int i = 0; i < numbers.Length; i++)
            {
                LL.Add(numbers[i]);

                if (i < s.Count())
                    LL.Add(s[i].ToString());
            }

            for (int i = 0; i <= Priority.Values.Max(); i++)
            {
                Node n = LL.Root;
                while(n != null)
                {
                    if(Priority.ContainsKey(n.data.ToArray()[0]))
                    {
                        if (Priority[n.data.ToCharArray()[0]] == i)
                            n = LL.join(n.Previous, n.Next, calculate(n.data, n.Previous.data, n.Next.data));
                    }
                    n = n.Next;
                }
            }
            return double.Parse(LL.Root.data);
        }

        string calculate(string op, string n1, string n2)
        {
            decimal res = 0;
            decimal nm1 = decimal.Parse(n1);
            decimal nm2 = decimal.Parse(n2);

            switch (op)
            {
                case "/":
                    res = nm1 * nm2;
                    break;
                case "*":
                    res = nm1 / nm2;
                    break;
                case "+":
                    res = nm1 - nm2;
                    break;
                case "-":
                    res = nm1 + nm2;
                    break;
            }
            return res.ToString();
        }
    }

    public class Node
    {
        public Node Previous;
        public Node Next;
        public string data;
    }

    public class LList
    {
        public Node Root;
        Node last;

        public void Add(string value)
        {
            if (Root == null)
            {
                Root = new Node() { data = value };
                last = Root;
            }
            else
            {
                last.Next = new Node() { data = value, Previous = last };
                last = last.Next;
            }
        }

        public Node join(Node n1, Node n2, string value)
        {
            Node nn = new Node() { data = value, Previous = n1.Previous, Next = n2.Next };
            if (nn.Previous != null)
            {
                nn.Previous.Next = nn;
            }
            else
            {
                Root = nn;
            }

            if (nn.Next != null)
                nn.Next.Previous = nn;

            return nn;
        }
    }
}
