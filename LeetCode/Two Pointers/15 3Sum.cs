/*
15 3Sum
Runtime: 204 ms, faster than 89.97% of C# online submissions for 3Sum.
Memory Usage: 48 MB, less than 65.76% of C# online submissions for 3Sum.
*/
public class Solution
{    
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var numsLength = nums.Length;
        var result = new List<IList<int>>();
    
		for (var i = 0; i < numsLength; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            
            var j = i + 1;
            var k = numsLength - 1;
            
            while (j < k)
            {
                var threeSum = nums[i] + nums[j] + nums[k];
                if (threeSum > 0)
                {
                    k--;
                }
                else if (threeSum < 0)
                {
                    j++;
                }
                else
                {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });
                    j++;
                    
                    while (nums[j] == nums[j - 1] && j < k)
                    {
                        j++;
                    }
                }
            }
        }

        return result;
    }
}