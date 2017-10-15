using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitLines
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputItems = new List<string>()
            {
                "f fa  fa ba",
                "  f fa  fa ba  ",
                "It was the best of times, it was the worst of times, it was the age of wisdom, it was the age of foolishness, it was the epoch of belief, it was the epoch of incredulity, it was the season of Light, it was the season of Darkness, it was the spring of hope, it was the winter of despair, we had everything before us, we had nothing before us, we were all going direct to Heaven, we were all going direct the other way--in short, the period was so far like the present period, that some of its noisiest authorities insisted on its being received, for good or for evil, in the superlative degree of comparison only.",
                "foo",
                ""
            };

            inputItems.ForEach(i => {
                Console.WriteLine("Input = {0}", i);
                Run(i.Trim());
            });
            Console.ReadLine();
        }

        static void Run(string input)
        {
            int count = 0;
            List<string> output = GetLinesSmallToLarge(input, out count);
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Small to Large!!!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintItems(output, count);
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Large to Small - with space!!!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            output.Reverse();
            PrintItems(output, count);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            output = GetLinesLargeToSmall_ConstantSpace(input, out count);
            Console.WriteLine("Large to Small constant space!!!");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintItems(output, count);
            Console.ForegroundColor = color;
        }

        static void PrintItems(List<string> output, int count)
        {
            foreach (string outputItem in output)
            {
                Console.WriteLine(outputItem);
            }

            Console.WriteLine("{0} lines", count);
        }

        static List<string> GetLinesSmallToLarge(string input, out int count)
        {
            count = 0;
            int length = 0;
            List<string> output = new List<string>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                List<string> inputList = input.Split(new char[] { ' ' }).ToList();
                StringBuilder stringToAdd = new StringBuilder();
                foreach (string inputitem in inputList)
                {
                    stringToAdd.Append(inputitem + " ");
                    if (stringToAdd.Length > length)
                    {
                        length = stringToAdd.Length;
                        output.Add(stringToAdd.ToString());
                        stringToAdd.Clear();
                        count++;
                    }
                }

                output[count - 1] = string.Format("{0} {1}", output[count - 1], stringToAdd);
            }

            return output;
        }

        static List<string> GetLinesLargeToSmall_ConstantSpace(string input, out int count)
        {
            count = 0;
            int length = 0;
            List<string> output = new List<string>();
            List<int> outputItemCount = new List<int>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                int wordCount = input.Split(new char[] { ' ' }).Count();
                int Length = input.Length;
            }

            return output;
        }


        static List<string> GetLinesLargeToSmall_ConstantSpaceOld(string input, out int count)
        {
            count = 0;
            int length = 0;
            List<string> output = new List<string>();
            List<int> outputItemCount = new List<int>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                List<string> inputList = input.Split(new char[] { ' ' }).ToList();
                StringBuilder stringToAdd = new StringBuilder();
                int itemCount = 0;
                int totalWordCount = 0;
                foreach (string inputitem in inputList)
                {
                    stringToAdd.Append(inputitem + " ");
                    itemCount++;
                    totalWordCount++;
                    if (stringToAdd.Length > length)
                    {
                        length = stringToAdd.Length;
                        outputItemCount.Add(itemCount);
                        stringToAdd.Clear();
                        itemCount = 0;
                        count++;
                    }
                }

                int lastItemCount = outputItemCount.Last();
                outputItemCount[count - 1] = lastItemCount + itemCount;
                for (int i = outputItemCount.Count() - 1; i >= 0; i--)
                {
                    int startIndex = totalWordCount - outputItemCount[i];
                    output.Add(string.Join(" ", inputList.Skip(startIndex).Take(outputItemCount[i])));
                    totalWordCount = startIndex;
                }
            }

            return output;
        }
    }
}