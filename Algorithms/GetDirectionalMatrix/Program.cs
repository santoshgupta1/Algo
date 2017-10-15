using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDirectionalMatrixPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 5, n = 5;
            int[,] result = GetSumMatrix(n);
            for(int i=0; i<m;i++)
            {
                for(int j=0; j < n; j++)
                {
                    Console.Write("{0} ", result[i, j]);
                }
                Console.WriteLine();
            }

            Console.Read();
        }

        static int[,] GetSumMatrix(int n)
        {
            int[,] output = new int[n, n];
            if (n%2 != 1)
            {
                return null;
            }
            int data = 1;
            int i=n/2, j = n-1;
            while ( data <= n*n)
            {
                Console.WriteLine("{0},{1}: {2}", i, j, data);
                output[i, j] = data++;
                if (j >= n-1)
                {
                    i=i-1;
                    j=0;
                }
                else if(i<=0 && j <n)
                {
                    i = n-1;
                    j = j + 1;
                }
                else
                {
                    i = i - 1;
                    j = j + 1;
                }

                if (output[i,j]!= 0)
                {
                    j--;
                }
            }

            return output;
        }
        static int[,] GetDirectionalMatrix(int m, int n)
        {
            int[,] output = new int[m, n];
            int data = 1;
            int i = 0, j = 0;
            bool downDirection = false;
            while (data <= m * n)
            {
                downDirection = !downDirection;
                while (i < m && i >= 0 && j < n && j >= 0)
                {
                    Console.WriteLine("{0},{1}: {2}", i, j, data);
                    output[i, j] = data++;
                    if (downDirection)
                    {
                        i--;
                        j++;
                    }
                    else
                    {
                        i++;
                        j--;
                    }
                }

                if (i < 0 && j >= 0 && j < n)
                {
                    i++;
                }
                else if (i >= 0 && i < m && j < 0)
                {
                    j++;
                }
                else if (i >= m && j >= 0 && j < n)
                {
                    // twice
                    i--;
                    j = j + 2;
                }
                else if (i >= m && j < 0)
                {
                    // once
                    i--;
                    j = j + 2;
                }
                else if (i >= 0 && i < m && j >= n)
                {
                    // twice
                    i = i + 2;
                    j--;
                }
                else if (i < 0 && j >= n)
                {
                    // once
                    i = i + 2;
                    j--;
                }
            }
            return output;
        }
    }
}
