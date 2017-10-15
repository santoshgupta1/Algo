using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "umamadammd";
            GetLongestPalindrome(data);
            Console.ReadKey();
        }

        static void GetLongestPalindrome(string data)
        {
            int size = data.Length;
            bool[,] map = new bool[size,size];
            for(int i = 0; i< size; i++)
            {
                map[i, i] = true;
            }
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<i; j++)
                {
                    if(data[i] ==data[j] && map[i-1, j+1] && j+1<size)
                    {
                        map[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", map[i, j] ? 1 : 0);
                }

                Console.WriteLine();
            }
        }
    }
}
