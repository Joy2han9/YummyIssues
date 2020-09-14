using System;
using System.Collections.Generic;
using System.Linq;

namespace issue21
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = GetListNode(new int[] { 1, 2, 4 });
            var l2 = GetListNode(new int[] { 1, 3, 4 });
            var result = MergeTwoLists(l1, l2);     //my
            //var result = MergeTwoLists2(l1, l2);  //better

            Console.ReadKey();
        }
        
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var list = new List<ListNode>();
            var temp = l1;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.next;
            }

            temp = l2;
            while(temp != null)
            {
                list.Add(temp);
                temp = temp.next;
            }

            var myArray = list.OrderBy(x => x.val).ToArray();
            for(var i = 0; i < myArray.Length-1; i++)
            {
                myArray[i].next = myArray[i + 1];
            }

            myArray[myArray.Length - 1].next = null;
            return myArray[0];
        }

        public static ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var node = new ListNode(0);
            var result = node;
            while(l1!=null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    result.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    result.next = l2;
                    l2 = l2.next;
                }
                result = result.next;
            }

            if (l1 != null)
            {
                result.next = l1;                
            }
            if (l2 != null)
            {
                result.next = l2;
            }

            return node.next;
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
