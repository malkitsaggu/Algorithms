using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;

namespace Algorithms
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }
        }

        public void Add(string data)
        {
            Node newNode = new Node();
            newNode.Data = data;

            newNode.Next = Head;
            Head = newNode;
        }

        /// <summary>
        /// Delete first node
        /// Time Complexity O(N)
        /// </summary>
        public void Delete()
        {
            if (Head != null)
            {
                Node temp = Head;
                Head = Head.Next;
            }
        }

        public void Print()
        {
            Node temp = Head;

            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }

            // PrintRecursive(Head);
        }

        public void PrintRecursive(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);
            PrintRecursive(node.Next);
        }

        public void PrintReverse()
        {
            Stack<string> stack = new Stack<string>();
            Node temp = Head;

            while (temp != null)
            {
                stack.Push(temp.Data);
                temp = temp.Next;
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            //PrintReverseRecursive(Head);
        }

        public void PrintReverseRecursive(Node node)
        {
            if (node == null)
            {
                return;
            }

            PrintReverseRecursive(node.Next);
            Console.WriteLine(node.Data);
        }

        public Node Search(string data)
        {
            var temp = Head;
            while (temp != null)
            {
                if (temp.Data == data)
                {
                    return temp;
                }

                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }

            return null;
        }

        public void Delete(string data)
        {

        }

        // Worst case time complexity: Θ(N)
        // Average case time complexity: Θ(N)
        // Best case time complexity: Θ(N)
        // Space complexity: Θ(1)
        public Node FindMiddleNode()
        {
            Node slowPointer = Head;
            Node fastPointer = Head;

            while (fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
            }
            return slowPointer;
        }

        //Time Complexity: O(n)
        //Auxiliary Space: O(1)
        public bool HasLoop()
        {
            Node slowPointer = Head;
            Node fastPointer = Head;

            while (slowPointer != null && fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;

                if (slowPointer == fastPointer)
                {
                    return true;
                }
            }

            return false;
        }

        //Time Complexity: O(n)
        //Auxiliary Space: O(n)
        public bool HasLoopUsingHashset()
        {
            HashSet<Node> hashset = new HashSet<Node>();

            Node temp = Head;

            while (temp != null)
            {
                if (hashset.Contains(temp))
                {
                    return true;
                }

                hashset.Add(temp);
                temp = temp.Next;
            }

            return false;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public void ReverseUsingLoop()
        {
            Node prev, curr, next;
            curr = Head;
            prev = null;
            next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            Head = prev;
        }

        public void ReverseUsingRecursion()
        {

        }

        public int GetLength()
        {
            int counter = 0;

            Node temp = Head;
            while (temp != null)
            {
                counter++;
                temp = temp.Next;
            }
            return counter;

            // return GetLengthUsingRecursion(Head);
        }

        public int GetLengthUsingRecursion(Node node)
        {
            // Base case
            if (node == null)
            {
                return 0;
            }

            return 1 + GetLengthUsingRecursion(node.Next);
        }

        public void RemoveDuplicatesInUnsorted()
        {
            Node temp1 = Head;
            Node temp2 = null;

            while (temp1 != null && temp1.Next != null)
            {
                temp2 = temp1;
                while (temp2.Next != null)
                {
                    if (temp1.Data == temp2.Next.Data)
                    {
                        Console.WriteLine("{0} is duplicate", temp2.Data);
                    }

                    temp2 = temp2.Next;
                }

                temp1 = temp1.Next;
            }
        }

        //Time Complexity: O(n)
        public string PrintNthNodeFromLast(int n)
        {
            Node slowPointer = Head;
            Node fastPointer = Head;

            if (Head != null)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (fastPointer == null)
                    {
                        return null;
                    }

                    fastPointer = fastPointer.Next;
                }

                while (fastPointer != null)
                {
                    slowPointer = slowPointer.Next;
                    fastPointer = fastPointer.Next;
                }
                return slowPointer.Data;
            }
            return null;
        }

        public Node IntersectionPointOfTwoLinkedList(Node node1, Node node2)
        {
            HashSet<Node> hashset = new HashSet<Node>();

            while (node1 != null)
            {
                hashset.Add(node1);
                node1 = node1.Next;
            }

            while (node2 != null)
            {
                if (hashset.Contains(node2))
                {
                    return node2;
                }

                node2 = node2.Next;
            }

            return null;
        }
    }
}
