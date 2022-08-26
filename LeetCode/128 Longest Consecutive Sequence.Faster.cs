/*
128 Longest Consecutive Sequence with Proper O(n) (Faster?)
Runtime: 548 ms, faster than 9.69% of C# online submissions for Longest Consecutive Sequence.
Memory Usage: 46.1 MB, less than 66.60% of C# online submissions for Longest Consecutive Sequence.
*/
public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var numsLength = nums.Length;   
        if (numsLength < 1)
            return 0;
        
        var numsHashSet = new HashSet<int>(nums);
        var maxLongestSequence = 0;
        int latestLongestSequence;
        
        for (var i = 0; i < numsLength; i++)
        {
            if (!numsHashSet.Contains(nums[i] - 1))
            {
                latestLongestSequence = 1;
                while (numsHashSet.Contains(nums[i] + latestLongestSequence))
                {
                    latestLongestSequence++;
                }
                
                maxLongestSequence = Math.Max(latestLongestSequence, maxLongestSequence);
            }
        }

        return maxLongestSequence;
    }
}