/*
347 Top K Frequent Elements (Faster without LINQ)
Runtime: 165 ms, faster than 88.45% of C# online submissions for Top K Frequent Elements.
Memory Usage: 46 MB, less than 21.26% of C# online submissions for Top K Frequent Elements.
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
        
        var queue = new PriorityQueue<int, int>();
        foreach (var kvp in dict)
        {
            queue.Enqueue(kvp.Key, kvp.Value);
            
            if (queue.Count > k)
            {
                queue.Dequeue();
            }
        }
        
        var solution = new int[k];
        var p = k - 1;
        while(queue.Count > 0)
        {
            solution[p] = queue.Dequeue();
            p--;
        }
        
        return solution;
    }
}