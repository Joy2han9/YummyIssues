using System;
using System.Collections.Generic;
using System.Linq;

namespace Issue2
{
    //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序的方式存储的，并且它们的每个节点只能存储 一位数字。

    //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

    //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

    //示例：

    //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    //输出：7 -> 0 -> 8
    //原因：342 + 465 = 807
    class Program
    {
        /// <summary>
        /// 将node转换成数字，作和后再转成node.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var program = new Program();
            ListNode ln1 = new ListNode(2);
            ListNode ln2 = new ListNode(4);
            ListNode ln3 = new ListNode(3);

            ListNode ln4 = new ListNode(5);
            ListNode ln5 = new ListNode(6);
            ListNode ln6 = new ListNode(4);

            ln2.next = ln3;
            ln1.next = ln2;

            ln5.next = ln6;
            ln4.next = ln5;

            program.AddTwoNumbers(ln1, ln4);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var str1 = GetNumber(l1);
            var str2 = GetNumber(l2);
            var result = StrAdd(str1, str2);

            return GetListNode(result);
        }
        /// <summary>
        /// 字符串数字相加
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public string StrAdd(string digit1, string digit2)
        {
            String result = "";
            char[] s1 = digit1.ToCharArray();
            char[] s2 = digit2.ToCharArray();
            char[] newS = new char[Math.Max(s1.Length, s2.Length) + 1];
            int carry = 0; // 表示进位
            for (int i = 0; i < newS.Length; i++)
            {
                char num1 = '0';
                char num2 = '0';
                if (s1.Length - 1 - i >= 0)
                {
                    num1 = s1[s1.Length - 1 - i];
                }
                if (s2.Length - 1 - i >= 0)
                {
                    num2 = s2[s2.Length - 1 - i];
                }
                if (num1 < '0' || num1 > '9' || num2 < '0' || num2 > '9')
                {
                    throw new Exception("必须是数字才行");
                }
                char num = (char)(num1 + num2 - '0' + carry);
                if (num > '9')
                {
                    carry = 1;
                    num = (char)(num - 10);
                }
                else
                {
                    carry = 0;
                }
                newS[newS.Length - 1 - i] = num;
            }
            for (int i = 0; i < newS.Length; i++)
            {
                if (i == 0 && newS[i] == '0')
                {
                }
                else
                {
                    result += newS[i];
                }
            }
            return result;
        }
        /// <summary>
        /// 根据listNode来获取数字字符串
        /// </summary>
        /// <param name="listNode"></param>
        /// <returns></returns>
        public string GetNumber(ListNode listNode)
        {
            string tempResult = listNode.val.ToString();
            while (listNode.next != null)
            {
                var next = listNode.next;
                tempResult += next.val.ToString();
                listNode = listNode.next;
            }

            return string.Join("", tempResult.ToCharArray().Reverse().ToList());
        }
        /// <summary>
        /// 根据数字字符串来构造listNode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public ListNode GetListNode(string str)
        {
            var numStrList = str.ToCharArray().Reverse().ToList();
            var listNode = new ListNode(int.Parse(numStrList[0].ToString()));
            var ListNodes = new List<ListNode>();
            for (var i = 1; i < numStrList.Count(); i++)
            {
                var listNodeNext = new ListNode(int.Parse(numStrList[i].ToString()));
                ListNodes.Add(listNodeNext);
            }

            if (ListNodes.Count == 0)
            {
                return listNode;
            }

            if (ListNodes.Count == 1)
            {
                listNode.next = ListNodes[0];
                return listNode;
            }

            for (var i = 0; i < ListNodes.Count - 1; i++)
            {
                ListNodes[i].next = ListNodes[i + 1];
            }

            listNode.next = ListNodes[0];
            return listNode;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
