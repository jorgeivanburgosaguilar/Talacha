/*
876 Middle of the Linked List
Runtime: 114 ms, faster than 54.33% of C# online submissions for Middle of the Linked List.
Memory Usage: 36.5 MB, less than 71.54% of C# online submissions for Middle of the Linked List.
*/
using System;
using System.Collections.Generic;

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
    public static List<ListNode> ListNodeToGenericList(ListNode node)
    {
        var listListNode = new List<ListNode>();
        var currentNode = node;
        
        while (currentNode != null)
        {
            listListNode.Add(currentNode);
            currentNode = currentNode.next;
        }
        
        return listListNode;
    }
    
    public ListNode MiddleNode(ListNode head)
    {
        if (head.next == null)
            return head;
        
        if (head.next.next == null)
            return head.next;
        
        var listListNode = ListNodeToGenericList(head);
        var middleIndex = Math.Abs(listListNode.Count / 2);
        return listListNode[middleIndex];
    }
}