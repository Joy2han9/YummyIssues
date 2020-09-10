using System;
using System.Collections.Generic;

namespace issue19
{
    class Program
    {
        /*
         * 给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。

            示例：

            给定一个链表: 1->2->3->4->5, 和 n = 2.

            当删除了倒数第二个节点后，链表变为 1->2->3->5.
            说明：

            给定的 n 保证是有效的。

            进阶：

            你能尝试使用一趟扫描实现吗？
         */
        static void Main(string[] args)
        {
            var head = GetListNode(new int[] { 1, 2, 3, 4, 5 });
            RemoveNthFromEnd(head, 2);

            Console.ReadKey();
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return head;

            int count = 1;
            var current = head;
            var tempList = new List<ListNode>();
            tempList.Add(head);
            while (current.next != null)
            {
                current = current.next;
                tempList.Add(current);
                count++;
            }
            if (n == count)
            {
                return head.next;
            }

            tempList[count - n - 1].next = tempList[count - n].next;

            return head;
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

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
