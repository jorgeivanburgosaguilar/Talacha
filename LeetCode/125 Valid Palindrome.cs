/*
125 Valid Palindrome
Runtime: 116 ms, faster than 52.21% of C# online submissions for Valid Palindrome.
Memory Usage: 41 MB, less than 29.30% of C# online submissions for Valid Palindrome.
*/
public class Solution
{
    public bool IsPalindrome(string s)
    {
        if (s.Length == 1)
            return true;
        
        s = System.Text.RegularExpressions.Regex.Replace(s.ToLower(), @"[^0-9a-z]", string.Empty);
        
        var endIndex = s.Length - 1;
        for (var i = 0; i < s.Length; i++)
        {
            if (i > endIndex - i)
                break;
                
            if (s[i] != s[endIndex - i])
                return false;
        }
        
        return true;
    }
}