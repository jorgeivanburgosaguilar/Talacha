/*
15 3Sum WIP
*/
public class Solution
{
    public static string SortNums(int i, int j, int k)
    {
        var arr = new int[] { i, j, k };
        Array.Sort(arr);
        return $"{arr[0]}{arr[1]}{arr[2]}";
    }
    
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var numsLength = nums.Length;
        var result = new List<IList<int>>();
        var indexHashset = new HashSet<string>();
    
		for (var i = 0; i < numsLength; i++)
        {
            for (var j = 0; j < numsLength; j++)
            {
                if (j == i)
                {
                    continue;
                }
                
                var k = j + 1;
                if (k >= numsLength)
                {
                    k = 0;
                }
                
                while (k != i && k != j)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        if (indexHashset.Add(SortNums(nums[i], nums[j], nums[k])))
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        }
                    }

                    k++;
                    if (k >= numsLength)
                    {
                        k = 0;
                    }
                }
                
            }
        }

        return result;
    }
}