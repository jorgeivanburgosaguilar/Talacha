/*
42 Trapping Rain Water
Runtime: 104 ms, faster than 91.21% of C# online submissions for Trapping Rain Water.
Memory Usage: 43.1 MB, less than 5.16% of C# online submissions for Trapping Rain Water.
*/
public class Solution
{
    public int Trap(int[] height)
    {
        var heightLength = height.Length - 1;
        var maxLeft = new int[heightLength + 1];
        var maxRight = new int[heightLength + 1];
        var currentMaxHeight = 0;

        for (var i = 0; i <= heightLength; i++)
        {
            if (i == 0)
            {
                maxLeft[i] = 0;
                continue;
            }
            
            currentMaxHeight = Math.Max(height[i - 1], currentMaxHeight);
            maxLeft[i] = currentMaxHeight;
        }
        
        currentMaxHeight = 0;
        for (var i = heightLength; i >= 0; i--)
        {
            if (i == heightLength)
            {
                maxRight[i] = 0;
                continue;
            }
            
            currentMaxHeight = Math.Max(height[i + 1], currentMaxHeight);
            maxRight[i] = currentMaxHeight;
        }
        
        var maxWater = 0;
        for (var i = 0; i <= heightLength; i++)
        {
            var currentMaxWater = Math.Min(maxLeft[i], maxRight[i]) - height[i];
            maxWater += currentMaxWater > 0 ? currentMaxWater : 0;
        }
        
        return maxWater;
    }
}