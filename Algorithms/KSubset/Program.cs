using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSubset
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 10, 12, 3, 5, 18 };
            int k = 3;
            bool r = IsKSubsetPossbile(data, k);
            Console.WriteLine(r);
            Console.ReadKey();
        }

        static bool IsKSubsetPossbile(int[] data, int k)
        {
            if(k==1)
            {
                return true;
            }
            if(k<=0)
            {
                return false;
            }

            int sum = 0;
            for(int i=0; i<data.Length; i++)
            {
                sum = sum + data[i];
            }

            if(sum % k != 0)
            {
                return false;
            }

            int subsetSum = sum / k;
            bool[] taken = new bool[data.Length];
            int[] subsetSums = new int[k];
            return IsSubsetPossible(data, data.Length-1, k-1, subsetSum, taken, subsetSums, 0);
        }
        static bool IsSubsetPossible(int[] data, int n, int k, int expectedSum, bool[] taken,int[] subsetSums, int subsetIndex)
        {
            if(k == subsetIndex && subsetSums[subsetIndex] == expectedSum)
            {
                return true;
            }
            if(subsetIndex < k && subsetSums[subsetIndex] == expectedSum)
            {
                return IsSubsetPossible(data, n, k, expectedSum, taken, subsetSums, subsetIndex+1);
            }

                for (int i = 0; i<=n; i++)
            {
                if(taken[i])
                {
                    continue;
                }

                if(subsetSums[subsetIndex] + data[i] <= expectedSum)
                {
                    taken[i] = true;
                    subsetSums[subsetIndex] = subsetSums[subsetIndex] + data[i];
                    bool ispossible = IsSubsetPossible(data, n, k, expectedSum, taken, subsetSums, subsetIndex);
                    taken[i] = false;
                    subsetSums[subsetIndex] = subsetSums[subsetIndex] - data[i];
                    if(ispossible)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
