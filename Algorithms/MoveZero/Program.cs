using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 0, 4, 6, 5, 0,9,10,1,0,3,0,2};
            Print(a);
            Console.WriteLine("\nOutput:");
            Print(MoveZero(a));
            Console.ReadKey();
        }

        static void Print(int[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                Console.Write("{0},", a[i]);
            }
        }

        static int[] MoveZero(int[] a)
        {
            int[] b = new int[a.Length];
            int j = 0, count = 0;
            for(int i =0; i< a.Length; i++)
            {
                if(a[i]!=0)
                {
                    b[j] = a[i];
                    j++;
                }
                else
                {
                    count++;
                }
            }

            while(j < a.Length)
            {
                b[j] = 0;
                j++;
            }

            return b;
        }
    }
}
