using System;
using System.Collections.Generic;

namespace issue91
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = GetListNode(new int[] { 1, 2, 3, 4, 5 });
            head = ReverseBetween(head,2,4);
            Console.ReadKey();
        }

        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;
            var length = right - left + 1;
            var array = new int[length];
            var current = head;
            var index = 1;
            var arrayIndex = 0;
            while (current != null)
            {
                if(index>=left && index <= right)
                {
                    array[arrayIndex++] = current.val;                    
                }
                index++;
                current = current.next;
            }
            Array.Reverse(array);
            current = head;
            index = 1;
            arrayIndex = 0;
            while (current != null)
            {
                if (index >= left && index <= right)
                {
                    current.val = array[arrayIndex++];
                }
                index++;
                current = current.next;
            }

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
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
