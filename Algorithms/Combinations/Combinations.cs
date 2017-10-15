using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    public class Combinations
    {
        public static void GetCominations(char[] input, int len, int r)
        {
            char[] data = new char[r];
            GenerateCombination(input, data, 0, len, r, 0);
        }

        public static void PrintLine(char[] data, int r)
        {
            for (int i = 0; i < r; i++)
            {
                Console.Write(data[i]);
            }
            Console.WriteLine();
        }

        static void GenerateCombination(char[] input, char[] data, int start, int end, int r, int index)
        {
            if (r <= index)
            {
                PrintLine(data, r);
                return;
            }

            for (int i = start; i < end && end - i + 1 > r - index; i++)
            {
                data[index] = input[i];
                GenerateCombination(input, data, i + 1, end, r, index + 1);
            }
        }
    }
}
