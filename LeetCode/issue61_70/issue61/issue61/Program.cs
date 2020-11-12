using System;
using System.Collections.Generic;

namespace issue61
{
    class Program
    {
        /*
         * 给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。

            示例 1:

            输入: 1->2->3->4->5->NULL, k = 2
            输出: 4->5->1->2->3->NULL
            解释:
            向右旋转 1 步: 5->1->2->3->4->NULL
            向右旋转 2 步: 4->5->1->2->3->NULL
            示例 2:

            输入: 0->1->2->NULL, k = 4
            输出: 2->0->1->NULL
            解释:
            向右旋转 1 步: 2->0->1->NULL
            向右旋转 2 步: 1->2->0->NULL
            向右旋转 3 步: 0->1->2->NULL
            向右旋转 4 步: 2->0->1->NULL
         */
        static void Main(string[] args)
        {
            var head = GetListNode(new int[] { 1, 2, 3, 4, 5 });

            var result = RotateRight(head, 2);
        }

        public static ListNode RotateRight(ListNode head, int k)
        {
           if(head==null || head.next == null)
            {
                return head;
            }
            int count = 1;
            var end = head;
            while (end.next != null)
            {
                end = end.next;
                count++;
            }
            end.next = head;
            var time = k % count;
            time = count - time;
            while (time > 0)
            {
                end = end.next;
                time--;
            }            
            head = end.next;
            end.next = null;

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
