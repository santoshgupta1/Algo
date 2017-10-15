using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void QuickSort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int partitionIndex = GetPartitionIndex(arr, start, end);
                QuickSort(arr, start, partitionIndex-1);
                QuickSort(arr, partitionIndex+1, end);
            }
        }

        static int GetPartitionIndex(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int i = start-1;
            for(int j=start; j<=end-1;j++)
            {
                if(arr[j]<=pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i+1, end);

            return i + 1;
        }

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 2, 34, 5, 75, 8, 6};
            QuickSort(arr, 0, arr.Length-1);
            arr.ToList().ForEach(a => Console.Write("{0}->", a));
            Console.ReadKey();
        }
    }
}
