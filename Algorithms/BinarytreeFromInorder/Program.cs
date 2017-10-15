using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarytreeFromInorder
{
    class Program
    {
        public class Node
        {
            public char data;
            public Node left, right;

            public Node(char item)
            {
                data = item;
                left = right = null;
            }
        }
        public Node root;
        static int preIndex = 0;

         public static Node CreateTree(char[] inorder, char[] preorder, int start, int end)
        {
            if (start > end)
                return null;
                        
            Node node = new Node(preorder[preIndex++]);

            if (start == end)
                return node;

            int inIndex = FindElement(inorder, start, end, node.data);

            node.left = CreateTree(inorder, preorder, start, inIndex - 1);
            node.right = CreateTree(inorder, preorder, inIndex + 1, end);

            return node;
        }

        public static int FindElement(char[] arr, int strt, int end, char value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (arr[i] == value)
                    return i;
            }
            return i;
        }
        static void printInorder(Node node)
        {
            if (node == null)
                return;

            printInorder(node.left);
            
            Console.WriteLine(node.data + " ");

            printInorder(node.right);
        }

        static void Main(string[] args)
        {
            char[] inorder = new char[]{'D', 'B', 'E', 'A', 'F', 'C'};
            char[] preorder = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            int len = inorder.Length;
            Node root = CreateTree(inorder, preorder, 0, len - 1);

            // building the tree by printing inorder traversal
            Console.WriteLine("Inorder traversal of constructed tree is : ");
            printInorder(root);
            Console.ReadKey();
        }
    }
}

