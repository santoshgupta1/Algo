using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    public class DuplicateCombinations
    {
        private static HashSet<char> usedItems = new HashSet<char>();
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

            if (!usedItems.Contains(input[start]))
            {
                for (int i = start; i < end && end - i + 1 > r - index; i++)
                {
                        data[index] = input[i];
                        GenerateCombination(input, data, i + 1, end, r, index + 1);                        
                }

                usedItems.Add(input[start]);
            }
        }
    }
}
