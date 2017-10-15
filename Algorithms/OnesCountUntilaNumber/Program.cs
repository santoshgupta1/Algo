using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesCountUntilaNumber
{
    public class CountOnes
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetOnesCount(1235));
            Console.WriteLine(GetOnesCount(1000));
            //Console.WriteLine(GetOnesCount(990));
        }
        static List<int> GetDigits(int n)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n % 10);
                n = n / 10;
            }

            return digits;
        }

        static int GetOnesCount(int n)
        {
            int count = 0;
            int value = n;
            Dictionary<int, int> digitPlaceValue = new Dictionary<int, int>();
            List<int> digits = GetDigits(n);
            digitPlaceValue[0] = 0;
            for(int i = 1; i < digits.Count();i++)
            {
                digitPlaceValue[i] = (int)Math.Pow(10, (i - 1)) + (10 * digitPlaceValue[i - 1]);
            }

            for (int index= digits.Count()-1; index > 0; index--)
            {
                if (digits[index] > 1)
                {
                    count = count + (int)Math.Pow(10, index) + digits[index] * digitPlaceValue[index];
                }
                else 
                {
                    count = count + (digitPlaceValue[index] + n % (int)Math.Pow(10, index) + 1) * digits[index];
                }                
            }

            return n % 10 >= 1? count+1: count;
        }

    }
}
