using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortBeforeIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new[] { 2, 1, 2, 5, 1, 2, 6, 2, 1, 5 };
            // int[] input = new[] { 1, 2, 0, 3, 5, 1, 2, 6, 7, 2, 1, 5, 1, 2, 6, 2, 1, 5 };
            int index = 5;
            Console.WriteLine($"input: {string.Join(",", input).ToString()}");
            Console.WriteLine($"index: {index}, indexElement: {input[index]}");
            //int operationsCount = QuickSortIndex(input, input[index]);
            int operationsCount = SortOnIndex(input, input[index]);
            Console.WriteLine($"Output: {string.Join(",", input).ToString()}");
            Console.WriteLine($"ItemCount = {input.Length}, OperationsCount = {operationsCount}");
            Console.ReadKey();
        }
        
        static int SortOnIndex(int[] a, int pivot)
        {
            int operationCount = 0;
            int small = 0;
            int large = a.Length - 1;
            int equal = 0;
            
            while (equal <= large)
            {
                if (a[equal] < pivot)
                {
                    operationCount++;
                    Swap(a, small, equal);
                    small++;
                    equal++;
                }
                else if (a[equal] == pivot)
                {
                    operationCount++;
                    equal++;
                }
                else 
                {
                    operationCount++;
                    Swap(a, equal, large);
                    large--;
                }
            }

            return operationCount;
        }

        static int QuickSortIndex(int[] a, int pivot)
        {
            int operationCount = 0;
            int i = 0;
            int j = a.Length - 1;
            // first iteration
            while( i < j)
            {
                if(a[i] < pivot)
                {
                    operationCount++;
                    i++;
                }
                else if (a[j] >= pivot)
                {
                    operationCount++;
                    j--;
                }
                else if(a[i] > a[j])
                {
                    operationCount++;
                    Swap(a, i, j);
                    i++;
                    j--;
                }
            }

            // second iteration
            j = a.Length - 1;
            while(i < j)
            {
                if(a[i] <= pivot)
                {
                    operationCount++;
                    i++;
                }
                else if (a[j] != pivot)
                {
                    operationCount++;
                    j--;
                }
                else if (a[j] == pivot)
                {
                    operationCount++;
                    Swap(a, i, j);
                    i++;
                    j--;
                }
            }

            return operationCount;
        }

        static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
