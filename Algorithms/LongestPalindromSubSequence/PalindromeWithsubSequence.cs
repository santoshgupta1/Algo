using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromSubSequence
{
    class PalindromeWithsubSequence
    {
        static int subSeq1 = 0;
        static int subSeq2 = 0;
        static void Main1(string[] args)
        {
            string str1 = "DEFABCAABA";
            string str2 = new string(str1.ToCharArray().Reverse().ToArray());
            Dictionary<int, int> table = new Dictionary<int, int>();
            Dictionary<int, string> resultTable = new Dictionary<int, string>();
            string result1 = string.Empty;
            string result2 = string.Empty;
            int l1 = SubSequence1(str1, str2, str1.Length, str2.Length, out result1);
            int l2 = SubSequence(str1, str2, str1.Length, str2.Length, table, resultTable, out result2);
            Console.WriteLine($"{str1}-{str1.Length}-{subSeq1}-{l1}-{result1}");
            Console.WriteLine($"{str1}-{str1.Length}-{subSeq2}-{l2}-{result2}");
            Console.ReadKey();
        }

        static int SubSequence1(string str1, string str2, int m, int n, out string result)
        {
            subSeq1++;
            StringBuilder sb = new StringBuilder();
            if (m == 0 || n == 0)
            {
                result = sb.ToString();
                return 0;
            }
            if (str1[m - 1] == str2[n - 1])
            {
                string subResultString = string.Empty;
                int s = SubSequence1(str1, str2, m - 1, n - 1, out subResultString);
                sb.Append(str1[m - 1]);
                sb.Append(subResultString);
                result = sb.ToString();
                return 1 + s;
            }

            string subResultString1 = string.Empty;
            string subResultString2 = string.Empty;
            int s1 = SubSequence1(str1, str2, m - 1, n, out subResultString1);
            int s2 = SubSequence1(str1, str2, m, n - 1, out subResultString2);
            if (Math.Max(s1, s2) == s1)
            {
                sb.Append(subResultString1);
            }
            else
            {
                sb.Append(subResultString2);
            }
            
            result = sb.ToString();
            return Math.Max(s1, s2);
        }


        static int SubSequence(string str1, string str2, int m, int n, Dictionary<int, int> table, Dictionary<int, string> subStringTable, out string result)
        {
            subSeq2++;
            StringBuilder sb = new StringBuilder();
            int subStringLength = 0;
            string subString = string.Empty;
            if (m == 0 || n == 0)
            {
                Tuple<string, string, int, int> subSequence = new Tuple<string, string, int, int>(str1, str2, m, n);
                int subHashCode = subSequence.GetHashCode();
                if (!TryGetTableValue(subHashCode, table, subStringTable, out subStringLength, out subString))
                {
                    AddToTableValue(subHashCode, table, subStringTable, subStringLength, subString);
                }

                result = sb.ToString();
                return subStringLength;
            }
            if (str1[m - 1] == str2[n - 1])
            {                
                Tuple<string, string, int, int> sub = new Tuple<string, string, int, int>(str1, str2, m - 1, n - 1);
                int subHashCode = sub.GetHashCode();
                if (!TryGetTableValue(subHashCode, table, subStringTable, out subStringLength, out subString))
                {
                    subStringLength = SubSequence(str1, str2, m - 1, n - 1, table, subStringTable, out subString);
                    AddToTableValue(subHashCode, table, subStringTable, subStringLength, subString);
                }

                sb.Append(str1[m - 1]);
                sb.Append(subString);
                result = sb.ToString();
                return 1 + subStringLength;
            }
            
            
            Tuple<string, string, int, int> sub1 = new Tuple<string, string, int, int>(str1, str2, m - 1, n);
            int subHashCode1 = sub1.GetHashCode();
            Tuple<string, string, int, int> sub2 = new Tuple<string, string, int, int>(str1, str2, m , n -1);
            int subHashCode2 = sub2.GetHashCode();
            int subStringLength1 = 0;
            string subString1 = string.Empty;
            int subStringLength2 = 0;
            string subString2 = string.Empty;
            if (!TryGetTableValue(subHashCode1, table, subStringTable, out subStringLength1, out subString1))
            {
                subStringLength1 = SubSequence(str1, str2, m - 1, n, table, subStringTable, out subString1);
                AddToTableValue(subHashCode1, table, subStringTable, subStringLength1, subString1);
            }
            if (!TryGetTableValue(subHashCode2, table, subStringTable, out subStringLength2, out subString2))
            {
                subStringLength2 = SubSequence(str1, str2, m , n -1, table, subStringTable, out subString2);
                AddToTableValue(subHashCode2, table, subStringTable, subStringLength2, subString2);
            }

            if(Math.Max(subStringLength1, subStringLength2) == subStringLength1)
            {
                sb.Append(subString1);
                result = sb.ToString();
                return subStringLength1;
            }
            else
            {
                sb.Append(subString2);
                result = sb.ToString();
                return subStringLength2;
            }            
        }

        static bool TryGetTableValue(
            int hashCode, Dictionary<int, int> table, Dictionary<int, string> resultTable,
            out int subStringlength, out string subString)
        {
            bool result = false;
            subStringlength = 0;
            subString = string.Empty;
            if (table.ContainsKey(hashCode))
            {
                subStringlength = table[hashCode];
                subString = resultTable[hashCode];
                result = true;
            }

            return result;
        }

        static void AddToTableValue(
            int hashCode, Dictionary<int, int> table, Dictionary<int, string> resultTable,
            int subStringlength, string subString)
        {
            if (!table.ContainsKey(hashCode))
            {
                table.Add(hashCode, subStringlength);
                resultTable.Add(hashCode, subString);
            }
            
        }
    }
}
