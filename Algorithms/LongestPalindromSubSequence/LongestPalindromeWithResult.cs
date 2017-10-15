using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromSubSequence
{
    class PalindromeWithsubSequenceResult
    {
        static int subSeq1 = 0;
        static int subSeq2 = 0;
        static void Main(string[] args)
        {
            string str1 = "DEFABCAABA";
            string str2 = new string(str1.ToCharArray().Reverse().ToArray());
            Dictionary<int, int> table = new Dictionary<int, int>();
            int l1 = SubSequence1(str1, str2, str1.Length, str2.Length);
            int l2 = SubSequence(str1, str2, str1.Length, str2.Length, table);
            Console.WriteLine($"{l1}-{subSeq1}");
            Console.WriteLine($"{l2}-{subSeq2}");

            Console.ReadKey();
        }

        static int SubSequence1(string str1, string str2, int m, int n)
        {
            subSeq1++;
            if (m == 0 || n == 0)
            {
                return 0;
            }
            if (str1[m - 1] == str2[n - 1])
            {
                int s = SubSequence1(str1, str2, m - 1, n - 1);
                return 1 + s;
            }

            int s1 = SubSequence1(str1, str2, m - 1, n);
            int s2 = SubSequence1(str1, str2, m, n - 1);
            return Math.Max(s1, s2);
        }


        static int SubSequence(string str1, string str2, int m, int n, Dictionary<int, int> table)
        {
            subSeq2++;
            if (m == 0 || n == 0)
            {
                return 0;
            }
            if (str1[m - 1] == str2[n - 1])
            {
                Tuple<string, string, int, int> sub = new Tuple<string, string, int, int>(str1, str2, m - 1, n - 1);
                int subHashCode = sub.GetHashCode();
                int s = 0;
                if (table.ContainsKey(subHashCode))
                {
                    s = table[subHashCode];
                }
                else
                {
                    s = SubSequence(str1, str2, m - 1, n - 1, table);
                    table.Add(subHashCode, s);
                }

                return 1 + s;
            }

            Tuple<string, string, int, int> sub1 = new Tuple<string, string, int, int>(str1, str2, m - 1, n);
            int subHashCode1 = sub1.GetHashCode();
            int s1 = 0;
            if (table.ContainsKey(subHashCode1))
            {
                s1 = table[subHashCode1];
            }
            else
            {
                s1 = SubSequence(str1, str2, m - 1, n, table);
                table.Add(subHashCode1, s1);
            }

            Tuple<string, string, int, int> sub2 = new Tuple<string, string, int, int>(str1, str2, m, n - 1);
            int subHashCode2 = sub2.GetHashCode();
            int s2 = 0;
            if (table.ContainsKey(subHashCode2))
            {
                s2 = table[subHashCode2];
            }
            else
            {
                s2 = SubSequence(str1, str2, m, n - 1, table);
                table.Add(subHashCode2, s2);
            }

            return Math.Max(s1, s2);
        }
    }
}