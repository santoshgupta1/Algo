using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromSubSequence
{
    class Program
    {
        static void Main1(string[] args)
        {
            //Console.WriteLine(CheckPalindrome("bob"));
            //Console.WriteLine(CheckPalindrome("boba"));
            // GetSubSequences("abcd", 0).ForEach(Console.WriteLine);
            Console.WriteLine(GetLongestPalindromSubSequence("boba"));
            Console.WriteLine(GetLongestPalindromSubSequence("BBABCBCAB"));
            Console.WriteLine(GetLongestPalindromSubSequence("BBABCBCABBBAB"));
            // GetSubSequences("boba", 0).ForEach(Console.WriteLine);
            Console.ReadKey();
        }
        
        static string GetLongestPalindromSubSequence(string str)
        {
            List<string> allSubSequence = new List<string>();
            allSubSequence = GetSubSequences(str, 0);
            int maxLength = 0;
            string result = null;
            foreach(string seq in allSubSequence)
            {
                if(CheckPalindrome(seq) && seq.Length > maxLength)
                {
                    maxLength = seq.Length;
                    result = seq;
                }
            }

            return result;
        }

        static List<string> GetSubSequences(string str, int start)
        {
            List<string> result = new List<string>();
            if (start >= str.Length)
            {
                return result;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(str[start]);
            result.Add(sb.ToString());
            List<string> subResults = GetSubSequences(str, start + 1);
            result.AddRange(subResults);
            
            foreach(string s in subResults)
            {
                sb.Clear();
                sb.Append(str[start]);
                sb.Append(s);
                result.Add(sb.ToString());
            }

            return result;
        }

        static bool CheckPalindrome(string str)
        {
            int l = str.Length -1;
            for (int i = 0; i < (l+1) / 2; i++)
            {
                if (str[i] != str[l - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
