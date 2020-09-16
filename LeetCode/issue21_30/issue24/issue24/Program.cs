using System;
using System.Collections.Generic;
using System.Linq;

namespace issue24
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = GetListNode(new int[] {1,2,3,4});

            var result = SwapPairs(node);

            Console.ReadKey();
        }

        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;
            var nodeList = new List<ListNode>();
            var temp = head;
            while (temp != null)
            {
                nodeList.Add(temp);
                temp = temp.next;
            }

            var myArray = nodeList.Select(x => x.val).ToArray();
            var newArray = new int[myArray.Length];
            if (myArray.Length % 2 == 0)
            {
                for (var i = 0; i < myArray.Length; i++)
                {
                    if (i % 2 == 1) continue;

                    newArray[i] = myArray[i + 1];
                    newArray[i + 1] = myArray[i];
                }
            }
            else
            {
                for (var i = 0; i < myArray.Length - 1; i++)
                {
                    if (i % 2 == 1) continue;

                    newArray[i] = myArray[i + 1];
                    newArray[i + 1] = myArray[i];
                }
                newArray[myArray.Length - 1] = myArray[myArray.Length - 1];
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
