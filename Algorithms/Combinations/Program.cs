using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations;

namespace Combinations
{   
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aabcdef";
            //Combinations.GetCominations(input.ToCharArray(), input.Length, 3);
            //Console.ReadKey();
            Console.WriteLine("Avoiding duplicate");
            DuplicateCombinations.GetCominations(input.ToCharArray(), input.Length, 3);
            Console.ReadKey();
        }
    }
}
