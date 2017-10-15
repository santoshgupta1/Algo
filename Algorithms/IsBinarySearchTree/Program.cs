using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBinarySearchTree
{
    class Node
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

        public static Node CreateBinarySearchTree()
        {
            Node root = new Node(100);
            Node.AddChild(root, 20, 300);
            Node.AddChild(root.left, 14, null);
            Node.AddChild(root.left.left, 5, 16);
            Node.AddChild(root.right, null, 300);
            return root;
        }

        public static Node CreateBinaryTree1()
        {
            Node root = new Node(100);
            Node.AddChild(root, 20, 300);
            Node.AddChild(root.left, 14, null);
            Node.AddChild(root.left.left, 5, 16);
            Node.AddChild(root.right, null, 30);
            return root;
        }
        public static Node CreateBinaryTree2()
        {
            Node root = new Node(100);
            Node.AddChild(root, 20, 300);
            Node.AddChild(root.left, 14, null);
            Node.AddChild(root.left.left, 5, 4);
            Node.AddChild(root.right, null, 300);
            return root;
        }
        public static Node CreateBinaryTree3()
        {
            Node root = new Node(100);
            Node.AddChild(root, 20, 300);
            Node.AddChild(root.left, 14, null);
            Node.AddChild(root.left.left, 50, 14);
            Node.AddChild(root.right, null, 300);
            return root;
        }

        public static Node CreateBinaryTree4()
        {
            Node root = new Node(10);
            Node.AddChild(root, 9, 11);
            Node.AddChild(root.left, 7, 12);
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = Node.CreateBinaryTree4();
            // bool result = CheckBinarySearchTree(root, int.MinValue, int.MaxValue);
            bool result = CheckBinarySearchTree1(root);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static bool CheckBinarySearchTree(Node node, int minValue, int maxValue)
        {

            if(node == null)
            {
                return true;
            }
            else
            {
                return (node.data >= minValue && node.data <= maxValue)
                    && CheckBinarySearchTree(node.left, minValue, node.data)
                    && CheckBinarySearchTree(node.right, node.data, maxValue);
            }
        }

        static bool CheckBinarySearchTree1(Node node)
        {
            Stack<Tuple<Node, int, int>> stack = new Stack<Tuple<Node, int, int>>();
            stack.Push(new Tuple<Node, int, int>(node, int.MinValue, int.MaxValue));
            bool result = true;
            while (stack.Any())
            {
                Tuple<Node, int, int> stackNode = stack.Pop();
                result = result && (stackNode.Item1.data >= stackNode.Item2 && stackNode.Item1.data <= stackNode.Item3);
                if(stackNode.Item1.left != null)
                {
                    stack.Push(new Tuple<Node, int, int>(stackNode.Item1.left, stackNode.Item2, stackNode.Item1.data));
                }

                if (stackNode.Item1.right != null)
                {
                    stack.Push(new Tuple<Node, int, int>(stackNode.Item1.right, stackNode.Item1.data, stackNode.Item3));
                }
            }
            return result;
        }
    }
}
