using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateKbitSkipThreeConsecutiveOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> output = new List<int>();
            KBitNumberSkipAfter2One(0, 4, 0, output);
            output.ForEach(o => Console.WriteLine(Convert.ToString(o, 2)));
            Console.ReadKey();
        }

        private static void KBitNumberSkipAfter2One(int currentValue, int k, int currentOneCount, List<int> output)
        {
            if (k < 0)
            {
                return;
            }

            output.Add(currentValue);
            if (currentValue > 0)
            {
                KBitNumberSkipAfter2One(currentValue << 1, k - 1, 0, output);
            }

            if (currentOneCount < 2)
            {
                KBitNumberSkipAfter2One((currentValue << 1) | 1, k - 1, currentOneCount + 1, output);
            }
        }
    }
}
