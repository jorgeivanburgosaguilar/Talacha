/*
217 Contains Duplicate
Runtime: 1243 ms, faster than 5.79% of C# online submissions for Contains Duplicate.
Memory Usage: 48.3 MB, less than 30.55% of C# online submissions for Contains Duplicate.
*/
public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    return true;
            }
        }

        return false;
    }
}