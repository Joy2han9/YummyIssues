using System;
using System.Collections.Generic;
using System.Linq;

namespace issue25
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = GetListNode(new int[] { 1, 2, 3, 4,5 });

            var result = ReverseKGroup(node,3);

            Console.ReadKey();
        }

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;
            if (head.next == null || k ==1) return head;
            var nodeList = new List<ListNode>();
            var temp = head;
            while (temp != null)
            {
                nodeList.Add(temp);
                temp = temp.next;
            }
            var myArray = nodeList.Select(x => x.val).ToArray();
            var newArray = new int[myArray.Length];
            if (myArray.Length % k == 0)
            {
                for (var i = 0; i < myArray.Length; i++)
                {
                    if (i % k != 0) continue;

                    for (var j = 0; j < k; j++)
                    {
                        newArray[i + j] = myArray[i + k - j-1];
                    }
                }
            }
            else
            {
                for (var i = 0; i < myArray.Length - myArray.Length % k; i++)
                {
                    if (i % k != 0) continue;

                    for (var j = 0; j < k; j++)
                    {
                        newArray[i + j] = myArray[i + k - j - 1];
                    }
                }
                for(var i= myArray.Length - myArray.Length % k; i < myArray.Length; i++)
                {
                    newArray[i] = myArray[i];
                }
            }

            var result = GetListNode(newArray);

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
        public ListNode(int x) { val = x; }
    }
}
