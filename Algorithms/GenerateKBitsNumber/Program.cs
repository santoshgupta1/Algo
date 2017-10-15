using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GenerateKBitsNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> output = new List<int>();
            KBitNumber(0, 3, output);
            output.ForEach(o => Console.WriteLine(Convert.ToString(o, 2)));
            Console.ReadKey();
        }

        private static void KBitNumber(int currentValue, int k, List<int> output)
        {
            if(k<0)
            {
                return;
            }

            output.Add(currentValue);
            if(currentValue > 0)
            {
                KBitNumber(currentValue << 1, k - 1, output);
            }

            KBitNumber((currentValue << 1) | 1, k - 1, output);
        }
    }
}
