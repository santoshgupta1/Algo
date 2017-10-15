using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreviousSmallestNode
{
    class Program
    {
        public class Node
        {
            public Node left = null;
            public Node right = null;
            public int data;
            public Node(int data)
            {
                this.data = data;
            }

            public static Node AddChild(Node node, int? left, int? right)
            {
                if (left.HasValue)
                {
                    node.left = new Node(left.Value);
                }
                if (right.HasValue)
                {
                    node.right = new Node(right.Value);
                }

                return node;
            }

            public static Node CreateBinarySearchTree1()
            {
                Node root = new Node(10);
                Node.AddChild(root, 5, 35);
                Node.AddChild(root.left, 2, 8);
                Node.AddChild(root.left.left, null, 3);
                Node.AddChild(root.right, 25, 45);
                Node.AddChild(root.right.left, 24, 29);
                return root;
            }
        }

        static void Main(string[] args)
        {
            Node root = Node.CreateBinarySearchTree1();
            Console.WriteLine("{0} - {1}", 29, FindPredecessor(root, 29));
            Console.WriteLine("{0} - {1}", 8, FindPredecessor(root, 8));
            Console.WriteLine("{0} - {1}", 24, FindPredecessor(root, 24));
            Console.WriteLine("{0} - {1}", 45, FindPredecessor(root, 45));

            Console.WriteLine("Successor");
            Console.WriteLine("{0} - {1}", 29, FindSuccesssor(root, 29));
            Console.WriteLine("{0} - {1}", 8, FindSuccesssor(root, 8));
            Console.WriteLine("{0} - {1}", 24, FindSuccesssor(root, 24));
            Console.WriteLine("{0} - {1}", 45, FindSuccesssor(root, 45));
            Console.ReadLine();
        }

        static int FindPredecessor(Node node, int expectedData)
        {
            int min = int.MinValue;
            while (node != null)
            {
                if (node.data < expectedData)
                {
                    min = node.data;
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }

            return min;
        }

        static int FindSuccesssor(Node node, int expectedData)
        {
            int max = int.MaxValue;
            while (node != null)
            {
                if (node.data > expectedData)
                {
                    max = node.data;
                    node = node.left;
                }
                else 
                {
                    node = node.right;
                }
            }

            return max;
        }
    }
}
