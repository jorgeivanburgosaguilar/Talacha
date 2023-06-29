/*
49 Group Anagrams
Runtime: 2858 ms, faster than 5.03% of C# online submissions for Group Anagrams.
Memory Usage: 48.7 MB, less than 97.32% of C# online submissions for Group Anagrams.
*/
public class Solution
{
    public static bool IsAnagram(string s, string t)
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
    
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var solution = new List<IList<string>>();
        
        if (strs.Length == 1)
        {
            solution.Add(new List<string> { strs[0] });
            return solution;
        }
        
        var alreadyTakenIndeces = new List<int>();
        for (var i = 0; i < strs.Length; i++)
        {
            if (alreadyTakenIndeces.Contains(i))
                continue;
                
            var lista = new List<string> { strs[i] };
            
            for (var j = i + 1; j < strs.Length; j++)
            {
                if (IsAnagram(strs[i], strs[j]))
                {
                    lista.Add(strs[j]);
                    alreadyTakenIndeces.Add(j);
                }
            }
            
            solution.Add(lista);
        }
        
        return solution;
    }
}