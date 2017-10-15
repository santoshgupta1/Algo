using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityVoting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> a = new List<int[]>
            {
                new int[] { 8,11,2,11,11,11,22,2,3,4,11,11,11},
                new int[] { },
                new int[] { 8,11},
                new int[] { 8,11,12,12,12,12},
            };

            a.ForEach(PrintMajorityVote);
            Console.ReadKey();
        }

        static void PrintMajorityVote(int[] items)
        {
            Console.WriteLine("check values:");
            int data = findDulplicate(items);
            Console.WriteLine(data);
        }

        static int findDulplicate(int[] items)
        {
            int result = 0;
            int count = 0;
            int duplicateItem = -1;
            foreach(int value in items)
            {
                if(value == duplicateItem)
                {
                    count++;
                }
                else if(count == 0)
                {
                    duplicateItem = value;
                    count= 1;
                }
                else
                {
                    count--;
                }
            }

            count = 0;
            foreach (int value in items)
            {
                if(value == duplicateItem)
                {
                    count++;
                }
            }

            if((count*2) > items.Length)
            {
                result = duplicateItem;
            }
            else
            {
                result = -1;
            }

            Console.WriteLine($"{duplicateItem} - {items.Length} - {count}");

            return result;
        }
    }
}
