using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "abc";
            Permute(data.ToCharArray(), 0, data.Length - 1);
            Console.ReadKey();
        }

        public static void Permute(char[] data, int start, int end)
        {
            if(start >= end)
            {
                Console.WriteLine(data);
            }
            else
            {
                for(int i = start; i <= end; i++)
                {
                    swap(data, i, start);
                    Permute(data, start + 1, end);
                    swap(data, i, start);
                }
            }
        }

        public static void swap(char[] data, int start, int end)
        {
            char temp = data[start];
            data[start] = data[end];
            data[end] = temp;
        }
    }
}
