/*
347 Top K Frequent Elements
Runtime: 280 ms, faster than 16.43% of C# online submissions for Top K Frequent Elements.
Memory Usage: 44.6 MB, less than 68.42% of C# online submissions for Top K Frequent Elements.
*/
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == 1)
        {
            return new int[] { k };
        }
        
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {     
                dict[nums[i]] = dict[nums[i]] + 1;
            }
            else
            {
                dict.Add(nums[i], 1);
            }
        }
        
        return dict.OrderByDescending(v => v.Value).Take(k).Select(k => k.Key).ToArray();
    }
}