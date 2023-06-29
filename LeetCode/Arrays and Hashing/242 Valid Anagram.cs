/*
242 Valid Anagram
Runtime: 322 ms, faster than 5.10% of C# online submissions for Valid Anagram.
Memory Usage: 39.1 MB, less than 41.06% of C# online submissions for Valid Anagram.
*/
using System;
using System.Linq;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
            
        var listT = t.ToList();
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 0; j < listT.Count; j++)
            {
                if (s[i] == listT[j])
                {
                    listT.RemoveAt(j);
                    break;
                }
            }
        }
        
        return listT.Count == 0;
    }
}