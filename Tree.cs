using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Node
    {
        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        // Root of Binary Tree 
        public Node root;
        public static int max_level = 0;
        public BinaryTree()
        {
            root = null;
        }

        /* Given a binary tree, print 
           its nodes in preorder*/
        public void printPreorder(Node node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.key + " ");

            /* then recur on left sutree */
            printPreorder(node.left);

            /* now recur on right subtree */
            printPreorder(node.right);
        }

        /* Given a binary tree, print  
           its nodes according to the 
           "bottom-up" postorder traversal. */
        public void printPostorder(Node node)
        {
            if (node == null)
                return;

            // first recur on left subtree 
            printPostorder(node.left);

            // then recur on right subtree 
            printPostorder(node.right);

            // now deal with the node 
            Console.Write(node.key + " ");
        }

        /* Given a binary tree, print  
           its nodes in inorder*/
        public void printInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.key + " ");

            /* now recur on right child */
            printInorder(node.right);
        }

        #region PreorderUsingStack

        public void PrintPreorderUsingStack(Node root)
        {
            Console.WriteLine("Preorder using Stack");
            Stack<Node> stack = new Stack<Node>();

            while (true)
            {
                while (root != null)
                {
                    Console.Write(root.key + " ");
                    stack.Push(root);
                    root = root.left;
                }

                if (stack.Count == 0)
                {
                    break;
                }

                root = stack.Pop();
                root = root.right;
            }
        }

        private void LeftViewUtil(Node node, int level)
        {
            // Base Case 
            if (node == null)
            {
                return;
            }

            // If this is the first node of its level 
            if (max_level < level)
            {
                Console.Write(" " + node.key);
                max_level = level;
            }

            // Recur for left and right subtrees 
            LeftViewUtil(node.left, level + 1);
            LeftViewUtil(node.right, level + 1);
        }

        public void LeftView()
        {
            LeftViewUtil(root, 1);
        }

        public static int MaxLevel = 0;
        public IList<int> RightSideView()
        {
            IList<int> rightViewList = new List<int>();
            RightView(root, 1, rightViewList);
            return rightViewList;
        }

        private void RightView(Node root, int level, IList<int> rightViewList)
        {

            if (root == null)
            {
                return;
            }

            if (MaxLevel < level)
            {
                rightViewList.Add(root.key);
                MaxLevel = level;
            }


            RightView(root.right, level + 1, rightViewList);
            RightView(root.left, level + 1, rightViewList);

        }

        #endregion

    }
}
