/*
15 3Sum (Lowest Memory)
Runtime: 341 ms, faster than 35.43% of C# online submissions for 3Sum.
Memory Usage: 42.9 MB, less than 100.00% of C# online submissions for 3Sum.
*/
public class Solution
{    
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency;
        Array.Sort(nums);
        var numsLength = nums.Length;
        var result = new List<IList<int>>();
    
		for (var i = 0; i < numsLength; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            
            var numI = nums[i];
            var j = i + 1;
            var k = numsLength - 1;
            
            while (j < k)
            {
                var numK = nums[k];
                var threeSum = numI + nums[j] + numK;
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
                    result.Add(new List<int> { numI, nums[j], numK });
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