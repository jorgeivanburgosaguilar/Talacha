/*
234 Palindrome Linked List
Runtime: 373 ms, faster than 51.12% of C# online submissions for Palindrome Linked List.
Memory Usage: 51.2 MB, less than 95.18% of C# online submissions for Palindrome Linked List.
*/
using System;
using System.Text;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public static string Reverse(string s)
    {
		if (s.Length < 2)
			return s;
		
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    
    public static string ListNodeToString(ListNode node)
    {
        if (node.next == null)
        {
            return node.val.ToString();
        }
        
        var strListNode = new StringBuilder();
        
        var currentNode = node;
        while (currentNode != null)
        {
            strListNode.Append(currentNode.val.ToString());
            currentNode = currentNode.next;
        }
        
        return strListNode.ToString();
    }
    
    public bool IsPalindrome(ListNode head)
    {
        var strListNode = ListNodeToString(head);
        var reverseStrListNode =  Reverse(strListNode);
        return strListNode == reverseStrListNode;
    }
}