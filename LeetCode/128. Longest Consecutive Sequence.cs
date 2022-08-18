/*
128. Longest Consecutive Sequence
Runtime: 197 ms, faster than 79.49% of C# online submissions for Longest Consecutive Sequence.
Memory Usage: 43.9 MB, less than 97.69% of C# online submissions for Longest Consecutive Sequence.
*/
public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var numsLength = nums.Length;   
        if (numsLength < 1)
            return 0;
            
        Array.Sort(nums);
        var maxLongestSequence = 1;
        var latestLongestSequence = 1;
        
        for (var i = 1; i < numsLength; i++)
        {
            if (nums[i - 1] == nums[i])
            {
                continue;
            }
            else if (nums[i - 1] == nums[i] - 1)
            {
                latestLongestSequence++;
            }
            else
            {
                maxLongestSequence = maxLongestSequence < latestLongestSequence ? latestLongestSequence : maxLongestSequence;
                latestLongestSequence = 1;
            }
        }
        
        maxLongestSequence = maxLongestSequence < latestLongestSequence ? latestLongestSequence : maxLongestSequence;
        
        return maxLongestSequence;
    }
}