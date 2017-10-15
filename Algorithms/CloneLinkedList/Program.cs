using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLinkedList
{
    class Program
    {
        class Node
        {
            public int data;
            public Node next;
            public Node rand; 
            public Node(int n)
            {
                this.data = n;
            }

            public void Link(Node nextNode, Node randNode)
            {
                this.next = nextNode;
                this.rand = randNode;
            }
        }
             
        static void Main(string[] args)
        {
            Node head = CreateLinkedList();
            PrintLinkedList(head);

            // Node cloneHead = CloneImmutableLinkedList(head);
            Node cloneHead = CloneMutableLinkedList(head);
            PrintLinkedList(cloneHead);
            Console.ReadKey();
        }

        static Node CreateLinkedList()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            node1.Link(node2, node5);
            node2.Link(node3, null);
            node3.Link(node4, node1);
            node4.Link(node5, node3);
            node5.Link(null, node2);
            return node1;
        }

        static void PrintLinkedList(Node root)
        {
            Node node = root;
            Console.WriteLine("\n Linked list Next");
            while(node != null)
            {
                Console.Write($"{node.data}-->");
                node = node.next;
            }

            Console.WriteLine("\n Linked list rand");
            node = root;
            while (node != null)
            {
                if (node.rand != null)
                {
                    Console.Write($"{node.rand.data}-->");
                }
                else
                {
                    Console.Write($"null-->");
                }
                node = node.next;
            }
        }

        static Node CloneMutableLinkedList(Node root)
        {
            // create node
            Node actualNode = root;
            Node cloneRoot = null;
            while (actualNode != null)
            {
                Node newNode = new Node(actualNode.data);
                cloneRoot = cloneRoot ?? newNode;
                newNode.next = actualNode.next;
                actualNode.next = newNode;
                actualNode = newNode.next;
            }

            // create rand link
            actualNode = root;
            Node cloneNode = null;
            while (actualNode != null)
            {
                cloneNode = actualNode.next;
                cloneNode.rand = actualNode.rand == null? null: actualNode.rand.next;
                actualNode = cloneNode.next;
            }

            // remove link
            actualNode = root;
            cloneNode = null;
            while (actualNode != null)
            {
                cloneNode = actualNode.next;
                actualNode.next = cloneNode.next;
                cloneNode.next = actualNode.next == null ? null : actualNode.next.next;
                actualNode = actualNode.next;
            }
            return cloneRoot;
        }

        static Node CloneImmutableLinkedList(Node root)
        {
            Node actualNode = root;
            Node cloneRoot = null;
            Dictionary<Node, Node> linkTable = new Dictionary<Node, Node>();
            while (actualNode != null)
            {
                Node newNode = new Node(actualNode.data);
                linkTable.Add(actualNode, newNode);
                cloneRoot = cloneRoot ?? newNode;
                actualNode = actualNode.next;
            }

            actualNode = root;
            while ( actualNode != null)
            {
                Node cloneNode = linkTable[actualNode];
                cloneNode.next = actualNode.next == null ? null : linkTable[actualNode.next];
                cloneNode.rand = actualNode.rand == null? null : linkTable[actualNode.rand];
                actualNode = actualNode.next;
            }

            return cloneRoot;
        }
    }
}
