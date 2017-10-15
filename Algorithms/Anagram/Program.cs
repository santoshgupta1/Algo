using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "xaxbbbxx";
            Console.WriteLine("IsAnagram : {0}", IsAnagram(data));
            Console.ReadLine();
        }

        static int IsAnagram(string data)
        {
            int changesNeeded = -1;
            bool isAnagram = data.Length % 2 != 1;
            if(isAnagram)
            {
                changesNeeded = 0;
                Dictionary<char, int> anagram = new Dictionary<char, int>();
                for (int i =0; i< data.Length; i++)
                {
                    if (i < data.Length / 2)
                    {
                        if (anagram.ContainsKey(data[i]))
                        {
                            anagram[data[i]]++;
                        }
                        else
                        {
                            anagram[data[i]] = 1;
                        }
                    }
                    else
                    {
                        if (anagram.ContainsKey(data[i]) && anagram[data[i]] > 0)
                        {
                            anagram[data[i]]--;
                        }
                        else
                        {
                            changesNeeded++;
                        }
                    }
                }
            }

            return changesNeeded;
        }
    }
}
