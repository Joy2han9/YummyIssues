using System;
using System.Collections.Generic;

namespace issue94
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode3 = new TreeNode
            {
                val = 3,
            };

            var treeNode2 = new TreeNode
            {
                val = 2,
                left = treeNode3,
            };

            var treeNode1 = new TreeNode
            {
                val = 1,
                right = treeNode2,
            };

            var result = InorderTraversal(treeNode1);
            Console.ReadKey();
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>() { };
            Helper(list, root);

            void Helper(List<int> tempList,TreeNode tree)
            {
                if (tree == null)
                {
                    return;
                }
                Helper(tempList, tree.left);
                tempList.Add(tree.val);
                Helper(tempList, tree.right);
            }

            return list;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
