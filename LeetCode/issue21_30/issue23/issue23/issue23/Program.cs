using System;
using System.Collections.Generic;
using System.Linq;

namespace issue23
{
    class Program
    {
        /*
         * 给你一个链表数组，每个链表都已经按升序排列。

            请你将所有链表合并到一个升序链表中，返回合并后的链表。

 

            示例 1：

            输入：lists = [[1,4,5],[1,3,4],[2,6]]
            输出：[1,1,2,3,4,4,5,6]
            解释：链表数组如下：
            [
              1->4->5,
              1->3->4,
              2->6
            ]
            将它们合并到一个有序链表中得到。
            1->1->2->3->4->4->5->6
            示例 2：

            输入：lists = []
            输出：[]
            示例 3：

            输入：lists = [[]]
            输出：[]
         */
        static void Main(string[] args)
        {
            var list = new List<List<int>>()
            {
                new List<int>(){1,4,5},
                new List<int>() { 1, 3, 4 },
                new List<int>() { 2,6 }
            };

            var myNodes = GetNodsWithListInt(list);

            var result = MergeKLists(myNodes);

            Console.ReadKey();
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }

            if (lists.All(x => x == null))
            {
                return null;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            var list = new List<ListNode>();
            foreach(var node in lists)
            {
                var temp = node;
                while (temp != null)
                {
                    list.Add(temp);
                    temp = temp.next;
                }
            }
            
            var myArray = list.OrderBy(x => x.val).ToArray();
            for (var i = 0; i < myArray.Length - 1; i++)
            {
                myArray[i].next = myArray[i + 1];
            }

            myArray[myArray.Length - 1].next = null;
            return myArray[0];
        }

        public static ListNode[] GetNodsWithListInt(List<List<int>> myList)
        {
            var currentList = new List<ListNode>();
            foreach(var list in myList)
            {
                currentList.Add(GetListNode(list.ToArray()));
            }

            return currentList.ToArray();
        }

        public static ListNode GetListNode(int[] intArray)
        {
            if (intArray.Length == 1)
            {
                return new ListNode(intArray[0]);
            }
            var head = new ListNode(intArray[0]);
            var nodes = new List<ListNode>();
            for (var i = 1; i < intArray.Length; i++)
            {
                var next = new ListNode(intArray[i]);
                nodes.Add(next);
            }

            for (var i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].next = nodes[i + 1];
            }

            head.next = nodes[0];

            return head;
        }
    }


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
