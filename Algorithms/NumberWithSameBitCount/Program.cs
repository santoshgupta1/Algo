using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWithSameBitCount
{
    class NumberBitCount
    {
        public static void Main()
        {
            // Enumerable.Range(1, 1000).ToList().ForEach(n =>
            //{
                int n = 35;
                int bitCount = GetBitCount(n);
                var linearcount = SameBitCount_LinearSolution(n, bitCount);
                long sameCount = SameBitCount_Optimal(n);
                Console.WriteLine($"{n} - {linearcount} - {sameCount}");
            //});
            Console.ReadKey();
        }
        private static long SameBitCount_LinearSolution(int n, int bitCount)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (GetBitCount(i) == bitCount)
                {
                    count++;
                }
            }

            return count;
        }

        private static long SameBitCount_Optimal(int n)
        {
            int totalBits;
            List<int> p = GetBitPositions(n, out totalBits);
            int count = 1;
            long bitcount = 0;
            p.ForEach(bitPosition =>
            {
                bitcount += Combination(bitPosition - 1, count++);                
            });


            return bitcount - n%2;
        }

        private static List<int> GetBitPositions(int n, out int totalBits)
        {
            totalBits = 0;
            List<int> positions = new List<int>();
            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    positions.Add(totalBits + 1);
                }

                n = n / 2;
                totalBits++;
            }

            return positions;
        }

        private static long Combination(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        static int GetBitCount(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count++;
                n = n & (n - 1);
            }

            return count;
        }
    }
}
