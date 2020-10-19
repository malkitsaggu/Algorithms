using System;

namespace Algorithms
{
    /// <summary>
    /// Stack using array
    /// </summary>
    public class StackUsingArray
    {
        private int[] arr;
        private int topIndex = -1;

        public StackUsingArray()
        {
            arr = new int[10];
        }

        public void Push(int data)
        {
            topIndex++;

            if (topIndex > arr.Length - 1)
            {
                int[] newArrr = new int[arr.Length + arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    newArrr[i] = arr[i];
                }

                arr = newArrr;
            }

            arr[topIndex] = data;
        }

        public void Pop()
        {
            if (topIndex > -1)
                topIndex--;
            else
                Console.WriteLine("No items in stack");
        }

        public int Top()
        {
            if (topIndex >= 0)
                return arr[topIndex];
            else
                return -1;
        }

        public bool IsEmpty()
        {
            return topIndex < 0;
        }
    }
}
