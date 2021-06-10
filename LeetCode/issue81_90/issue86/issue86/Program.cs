using System;
using System.Collections.Generic;

namespace issue86
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public ListNode Partition(ListNode head, int x)
        {
            if(head==null || head.next == null)
            {
                return head;
            }
            var lessArray = new List<int>() { };
            var largeArray = new List<int>() { };

            while (head != null)
            {
                if (head.val < x)
                {
                    lessArray.Add(head.val);
                }
                else
                {
                    largeArray.Add(head.val);
                }
                head = head.next;
            }
            lessArray.AddRange(largeArray);

            var result = GetListNode(lessArray.ToArray());

            return result;
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
