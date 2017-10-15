using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    static void Main()
    {
        //string[] words = { "This", "is", "an", "example", "of", "text", "justification."};

        // string[] words = { "Listen", "to", "many,", "speak", "to", "a", "few." };
        string[] words = { "a", "b", "c", "d", "e" };
    // string[] words = { "This", "is" };
    // string[] words = { "a" };
    //string[] words = { "" };
    int maxWidth = 3;
        IList<string>  output = FullJustify(words, maxWidth);
        output.ToList().ForEach(Console.WriteLine);
        Console.ReadKey();
    }

    public static IList<string> FullJustify(string[] words, int maxWidth)
    {
        IList<string> output = GetTextJustifiedItems(words, maxWidth);
        return output;
    }

    static List<string> GetTextJustifiedItems(string[] input, int lineLength)
    {
        List<string> output = new List<string>();

        if (input.Length > 0)
        {
            List<string> currentItems = new List<string>();
            foreach (string inputItem in input)
            {
                currentItems.Add(inputItem);
                if (string.Join(" ", currentItems).Length > lineLength)
                {
                    int lastItem = currentItems.Count - 1;
                    currentItems.RemoveAt(lastItem);
                    output.Add(GetJustifiedString(currentItems, lineLength));
                    currentItems.Clear();
                    currentItems.Add(inputItem);
                }
            }

            // output.Add(GetJustifiedString(currentItems, lineLength));
            output.Add(string.Join(" ", currentItems)+ CreateSpaceString(lineLength - string.Join(" ", currentItems).Length));
        }
        else
        {
            output.Add(string.Empty);
        }

        return output;
    }
    static string GetJustifiedString(List<string> inputItems, int length)
    {
        int spaceCount = length - string.Join("", inputItems).Length;
        System.Text.StringBuilder justifiedString = new StringBuilder();
        if (inputItems.Count > 1)
        {
            int spaceBetweenWords = spaceCount / (inputItems.Count() - 1);
            justifiedString.Append(inputItems.First());
            for (int i = 1; i < inputItems.Count() - 1; i++)
            {
                justifiedString.Append(CreateSpaceString(spaceBetweenWords));
                justifiedString.Append(inputItems[i]);
            }
        }

        int lastWordSpace = length - (justifiedString.Length + inputItems.Last().Length);
        justifiedString.Append(inputItems.Last());
        justifiedString.Append(CreateSpaceString(lastWordSpace));
        return justifiedString.ToString();
    }

    static string CreateSpaceString(int count)
    {
        StringBuilder spaces = new StringBuilder();
        spaces.Append(' ', count);
        return spaces.ToString();
    }
}
