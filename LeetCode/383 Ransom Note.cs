/*
383 Ransom Note
Runtime: 124 ms, faster than 52.06% of C# online submissions for Ransom Note.
Memory Usage: 41.1 MB, less than 31.01% of C# online submissions for Ransom Note.
*/
using System;
using System.Linq;

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var listaRansomNote = ransomNote.ToList();
        for (var i = 0; i < magazine.Length; i++)
        {
            for (var j = 0; j < listaRansomNote.Count; j++)
            {
                if (magazine[i] == listaRansomNote[j])
                {
                    listaRansomNote.RemoveAt(j);
                    break;
                }
            }
        }
        
        return listaRansomNote.Count == 0;
    }
}