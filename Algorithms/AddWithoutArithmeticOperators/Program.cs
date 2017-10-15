using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWithoutArithmeticOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(10, 20));
            Console.WriteLine(Add(98, 1));
            Console.WriteLine(Add(99, 1));
            Console.WriteLine(Add(99, 2));
            Console.WriteLine(Add(99, 99));
            Console.WriteLine(Add(7, 4));
            Console.ReadLine();
        }

        public static int Add(int a, int b)
        {
            int c = 0;
            int s = 0;
            do
            {
                s = a ^ b;
                c = (a & b) << 1;
                a = s;
                b = c;
            }
            while (c != 0);
            return s;
        }

        public static int Add3(int a, int b)
        {
            int c = 0;
            int s = 0;
            do
            {
                s = Add2(a, b, out c);
                a = s;
                b = c << 1;
            }
            while (c != 0);
            return s;
        }

        public static int Add2(int num1, int num2, out int carry)
        {
            int result = 0;
            int sum = 0;
            int a= 0, b =0;
            carry = 0;
            for(int i =0; i < 32; i++)
            {
                a = (num1 >> i) & 1;
                b = (num2 >> i) & 1;
                sum = a ^ b;
                carry = carry | (a & b) << i;
                result = result | sum << i;
            }

            return result;
        }

        static int Add1(int a, int b)
        {
            if (b == 0)
                return a;
            int sum = a ^ b;
            int carry = (a & b) << 1;
            return Add1(sum, carry);
        }
    }
}
