using System;
using System.Collections.Generic;

namespace issue83
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var stack = new Stack<int>();
            while (head != null)
            {
                if (stack.Count == 0)
                {
                    stack.Push(head.val);
                    head = head.next;
                    continue;
                }
                if (stack.Peek() == head.val)
                {
                    head = head.next;
                    continue;
                }
                else
                {
                    stack.Push(head.val);
                }
                head = head.next;
            }
            var array = stack.ToArray();
            Array.Reverse(array);
            var node = GetListNode(array);

            return node;
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
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
