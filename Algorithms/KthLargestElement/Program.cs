using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthLargestElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1,5,3,2,6,8,9,0};
            MinHeap minHeap = new MinHeap(a.Length);
            foreach(int item in a)
            {
                minHeap.insert(item);
            }
            Console.WriteLine("Print heap:");
            minHeap.print();

            Console.WriteLine("Start removing heap:");
            while (minHeap.current > 0)
            {
                int v = minHeap.Get();
                Console.WriteLine($"\nRemoved {v} : heap:");
                minHeap.print();
            }

            Console.ReadKey();
        }


        static int KthLargest(int[] a)
        {
             
            return 0;
        }

        static int Kth_UsingHeap(int[] a)
        {
            return 0;
        }

        private class MinHeap
        {
            int length = 0;
            public int current = 0;
            int[] items;
            public MinHeap(int length)
            {
                this.length = length;
                items = new int[length];
            }

            public void insert(int value)
            {
                items[this.current] = value;
                this.BottomUpHeapify();
                this.current = this.current + 1;
            }

            private void BottomUpHeapify()
            {
                int i = this.current;
                while(i > 0)
                {
                    int parent = i%2==0? (i-1)/2 : i/2;
                    if(this.items[i] < this.items[parent])
                    {
                        this.swap(parent, i);                                                        
                    }

                    i = parent;
                }
            }

            public int Get()
            {
                int i = 0;
                int result = this.items[i];
                this.items[i] = this.items[this.current - 1];
                this.current--;
                this.TopDownHeapify();
                return result;
            }

            private void TopDownHeapify()
            {
                int i = 0;
                while (i <= this.current)
                {
                    int leftChild = (2 * i) + 1;
                    int rightChild = (2 * i) + 2;
                    if(rightChild <= this.current && leftChild <= this.current)
                    {
                       int value = Math.Min(this.items[leftChild], this.items[rightChild]);
                       int index = value == this.items[leftChild] ? leftChild : rightChild;
                       if ( this.items[i] >= value)
                        {
                            this.swap(i, index);
                        }

                        i = index;
                    }
                    else if (rightChild <= this.current)
                    {
                        int value = this.items[rightChild];
                        int index = rightChild;
                        if (this.items[i] >= value)
                        {
                            this.swap(i, index);
                        }

                        i = index;
                    }
                    else if (leftChild <= this.current)
                    {
                        int value = this.items[leftChild];
                        int index = leftChild;
                        if (this.items[i] >= value)
                        {
                            this.swap(i, index);
                        }

                        i = index;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            private void TopDownHeapify1()
            {
                int i = 0;
                while (i < this.current)
                {
                    int leftChild = (2 * i) + 1;
                    int rightChild = (2 * i) + 2;
                    if(leftChild < this.current && this.items[i] >= this.items[leftChild] )
                    {
                        this.swap(i, leftChild);
                    }
                    else if (rightChild < this.current && this.items[i] >= this.items[rightChild])
                    {
                        this.swap(i, rightChild);
                    }
                    else
                    {
                        i = i+1;
                    }
                }
            }
            private void swap(int index1, int index2)
            {
                int temp = this.items[index1];
                this.items[index1] = this.items[index2];
                this.items[index2] = temp;
            }

            public void print()
            {
                for(int i=0; i< this.current; i++)
                {
                    Console.Write($"{this.items[i]}--"); ;
                }
            }
        }
    }
}
