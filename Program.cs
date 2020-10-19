using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int[] { 4, 3, 4, 4, 2, 4 };
            //int[] b = new int[] { 11, 3, 7, 1 };

            //var result = IsSubset(a, b, a.Length, b.Length);

            var result = FindMinimumDeleteToMakeAllElementsSame(a);

            //var a = DateTime.Parse("2020-08-12T11:45:29Z");

            //var utc = a.ToUniversalTime();

            //Stack<int> s = new Stack<int>();
            //s.Push(1);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);
            //s.Push(5);
            //ReverseStack(s);

            // DeleteMiddleOfStack(s, s.Count);
            //  Console.Read();
            //Console.WriteLine("Hello World!");
            //string[] str = new string[5] { "4", "13", "5", "/", "+" };

            //Console.WriteLine("Postfix eval is: " + EvalRPN(str));

            //StackUsingLinkedList stack = new StackUsingLinkedList();
            //stack.Push(22);

            //Console.WriteLine("Push: 22");
            //Console.WriteLine("Push: 33");

            //stack.Pop();
            //Console.WriteLine("Top item is: " + stack.Top());
            //Console.WriteLine("Stack is empty: " + stack.IsEmpty());

            //stack.Push(Convert.ToInt32(Console.ReadLine()));

            //Console.WriteLine("Top item is: " + stack.Top());
            //Console.WriteLine("Stack is empty: " + stack.IsEmpty());

            //stack.Push(Convert.ToInt32(Console.ReadLine()));
            //stack.Push(Convert.ToInt32(Console.ReadLine()));

            //Console.WriteLine("Top item is: " + stack.Top());
            //Console.WriteLine("Stack is empty: " + stack.IsEmpty());



            //stack.Pop();
            //Console.WriteLine("Top item is: " + stack.Top());
            //Console.WriteLine("Stack is empty: " + stack.IsEmpty());



            //BinaryTree tree = new BinaryTree();
            //tree.root = new Node(1);
            //tree.root.left = new Node(2);
            //tree.root.right = new Node(3);
            //tree.root.left.left = new Node(4);
            // tree.RightSideView();
            //tree.printPreorder(tree.root);
            //tree.PrintPreorderUsingStack(tree.root);
            //LinkedList linkedList = new LinkedList();
            //linkedList.Add("4");
            //linkedList.Add("3");
            //linkedList.Add("2");
            //linkedList.Add("1");

            //Create loop
            //linkedList.Head.Next.Next.Next.Next = linkedList.Head;

            //var middle = linkedList.FindMiddleNode();
            //var hasLoop = linkedList.HasLoop();
            //var hasLoop = linkedList.HasLoopUsingHashset();
            //linkedList.ReverseUsingLoop();
            //int length = linkedList.GetLength();
            //linkedList.Print();
            //linkedList.PrintReverse();
            //linkedList.RemoveDuplicatesInUnsorted();
            // var result = linkedList.PrintNthNodeFromLast(2);
            //String str = "Welcome";
            //String reversed = reverseString(str);
            //Console.WriteLine("The reversed string is: " + reversed);
            Console.ReadLine();
        }

        public static int FindMinimumDeleteToMakeAllElementsSame(int[] arr)
        {
            if (arr.Length == 0) { return 0; }

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map[arr[i]] = 1;
                }
                else
                {
                    map[arr[i]] = map[arr[i]] + 1;
                }
            }

            int max = 0;

            foreach (var item in map)
            {
                max = Math.Max(max, item.Value);
            }

            return arr.Length - max;
        }

        /// <summary>
        /// Is subset using Hashing
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="m">Size of a</param>
        /// <param name="n">Size of b</param>
        /// <returns></returns>
        public static bool IsSubset(int[] a, int[] b, int m, int n)
        {
            if (b.Length > a.Length) { return false; }

            HashSet<int> hashset = new HashSet<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!hashset.Contains(a[i]))
                {
                    hashset.Add(a[i]);
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!hashset.Contains(b[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static void DeleteMiddleOfStack(Stack<int> stack, int n, int counter = 0)
        {
            if (stack.Count == 0)
            {
                return;
            }

            int temp = stack.Pop();
            DeleteMiddleOfStack(stack, n, counter + 1);
            if (counter != n / 2)
            {
                stack.Push(temp);
            }

        }

        public static void ReverseStack(Stack<int> s)
        {
            if (s.Count == 0)
            {
                return;
            }

            int temp = s.Pop();

            ReverseStack(s);

            InsertInStack(s, temp);
        }

        public static void InsertInStack(Stack<int> s, int data)
        {
            if (s.Count == 0)
            {
                s.Push(data);
                return;
            }

            int temp = s.Pop();

            InsertInStack(s, data);

            s.Push(temp);
        }


        public static String reverseString(String str)
        {
            if ((str == null) || (str.Length <= 1))
                return str;

            return reverseString(str.Substring(1)) + str[0];
        }

        public static int EvalRPN(string[] tokens)
        {

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < tokens.Length; i++)
            {

                var isNumeric = int.TryParse(tokens[i], out int n);

                if (isNumeric)
                {
                    stack.Push(tokens[i]);
                }

                if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
                {

                    // if(stack.Count >1 ){

                    int op1 = Convert.ToInt32(stack.Pop());
                    int op2 = Convert.ToInt32(stack.Pop());
                    int result = 0;

                    if (tokens[i] == "+")
                    {
                        result = op1 + op2;
                    }
                    else if (tokens[i] == "-")
                    {
                        result = op1 - op2;
                    }
                    else if (tokens[i] == "*")
                    {
                        result = op1 * op2;
                    }
                    else if (tokens[i] == "/")
                    {
                        result = op1 / op2;
                    }

                    stack.Push(result.ToString());
                    //  }
                }
            }

            return Convert.ToInt32(stack.Peek());
        }
    }
}
