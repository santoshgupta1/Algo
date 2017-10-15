using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToScreeen
{
    class Program
    {
        private const char wordDelimiter = ' ';
        private const char lineMarker = '|';
        static void Main(string[] args)
        {
            string input = "hello world, how are you";
            int screenPixelLength = 7;
            Console.WriteLine(PrintLines(input, screenPixelLength));
            Console.ReadKey();
        }

        private static string PrintLines(string input, int screenPixelLength)
        {
            StringBuilder outputBuffer = new StringBuilder();
            int usedPixelSize = 0;
            int inputLength = input.Length;
            int currentIndex = 0;
            while(currentIndex < inputLength)
            {
                int nextWordLength = 0;
                int nextWordPixelSize = GetNextWordPixelSize(input, inputLength, currentIndex, screenPixelLength, out nextWordLength);
                if(nextWordPixelSize > screenPixelLength - usedPixelSize)
                {
                    outputBuffer.Append(lineMarker);
                    outputBuffer.AppendLine();
                    usedPixelSize = 0;
                }
                
                usedPixelSize = usedPixelSize + nextWordPixelSize;
                outputBuffer.Append(input.Substring(currentIndex, nextWordLength));
                currentIndex = currentIndex + nextWordLength;
            }

            return outputBuffer.ToString();
        }

        private static int GetNextWordPixelSize(string input, int inputLength, int startIndex, int maxWordPixelLength, out int nextWordLength)
        {
            int nextWordPixelSize = 0;
            nextWordLength = 0;
            if (input[startIndex] == wordDelimiter)
            {
                nextWordLength++;
                startIndex++;
                nextWordPixelSize = nextWordPixelSize + GetPixelForChar(input[startIndex]);
            }
            else
            {
                while (startIndex < inputLength && input[startIndex] != wordDelimiter)
                {
                    nextWordPixelSize = nextWordPixelSize + GetPixelForChar(input[startIndex]);
                    nextWordLength++;
                    startIndex++;
                    if (nextWordPixelSize > maxWordPixelLength)
                    {
                        throw new InvalidOperationException("Invalid input");
                    }
                }
            }

            return nextWordPixelSize;
        }
        
        private static int GetPixelForChar(char item)
        {
            int value = 1;
            if(item == 'y')
            {
                value = 5;
            }
            if (item == 'r')
            {
                value = 2;
            }
            if (item == 't')
            {
                value = 3;
            }
            if (item == ' ')
            {
                value = 1;
            }


            return value;
        }        
    }
}
