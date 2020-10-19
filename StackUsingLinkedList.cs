using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{

    public class LNode
    {
        public int Data { get; set; }
        public LNode Next { get; set; }
    }

    /// <summary>
    /// Stack using LinkedList
    /// </summary>
    public class StackUsingLinkedList
    {
        private LNode Head;

        public void Push(int data)
        {
            LNode node = new LNode();
            node.Data = data;
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        public void Pop()
        {
            if (Head != null)
            {
                Head = Head.Next;
            }
            else
            {
                Console.WriteLine("No items in stack");
            }
        }

        public int Top()
        {
            if (Head != null)
            {
                return Head.Data;
            }
            else
            {
                Console.WriteLine("No items in stack");
                return -1;
            }
        }

        public bool IsEmpty()
        {
            return Head == null;
        }
    }
}
