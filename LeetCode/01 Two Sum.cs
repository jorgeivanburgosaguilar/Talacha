/*
1 Two Sum
Runtime: 237 ms, faster than 45.77% of C# online submissions for Two Sum.
Memory Usage: 42.6 MB, less than 87.51% of C# online submissions for Two Sum.
*/
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j)
                    continue;

                if (nums[i] + nums[j] == target)
                    return new int[] { i, j };
            }

        }

        return new int[] { 0, 0 };
    }
}