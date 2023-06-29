/*
238 Product of Array Except Self
Runtime: 172 ms, faster than 94.88% of C# online submissions for Product of Array Except Self.
Memory Usage: 48.1 MB, less than 99.88% of C# online submissions for Product of Array Except Self.
*/
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var numsLength = nums.Length;
        if (numsLength < 2)
        {
            return nums;
        }
        
        var result = new int[numsLength];
        
        var prefix = 1;
        for (var i = 0; i < numsLength; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }
        
        var postfix = 1;
        for (var i = numsLength - 1; i >= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }
        
        return result;
    }
}

/*
These is my original solution for this problem, wasn't accepted due to runtime constrains,
couldn't solve it by myself, therefore m leaving here the original one i had in mind.
The one on top is a port from the python solution found on neetcode.io
*/
public class MyOriginalSolution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        
        for (var i = 0; i < nums.Length; i++)
        {
            var product = 1;
            
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }
                
                if (nums[j] == 0)
                {
                    product = 0;
                    break;
                }
                else
                {
                    product *= nums[j];
                }
            }
            
            result[i] = product;
        }
        
        return result;
    }
}