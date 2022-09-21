/*
11. Container With Most Water
Runtime: 196 ms, faster than 89.68% of C# online submissions for Container With Most Water.
Memory Usage: 50.3 MB, less than 15.18% of C# online submissions for Container With Most Water.
*/
public class Solution
{
    public int MaxArea(int[] height)
    {
        var indexAdd = 0;
        var indexSubstract = height.Length - 1;

        var maxArea = 0;
        while (indexAdd < indexSubstract)
        {
            var heightIndexAdd = height[indexAdd];
            var heightIndexSubstract = height[indexSubstract];

            maxArea = Math.Max((indexSubstract - indexAdd) * Math.Min(heightIndexAdd, heightIndexSubstract), maxArea);
            if (heightIndexAdd > heightIndexSubstract)
            {
                indexSubstract--;
            }
            else
            {
                indexAdd++;
            }
        }

        return maxArea;
    }
}