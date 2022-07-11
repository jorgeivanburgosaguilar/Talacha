/*
167 Two Sum II - Input Array Is Sorted
Runtime: 473 ms, faster than 5.89% of C# online submissions for Two Sum II - Input Array Is Sorted.
Memory Usage: 45.1 MB, less than 36.51% of C# online submissions for Two Sum II - Input Array Is Sorted.
*/
public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        if (numbers.Length == 2)
            return new int[] { 1, 2 };
        
        for (var i = numbers.Length - 1; i >= 0; i--)
        {
            if (target < 0)
            {
                if (numbers[i] < target)
                    continue;
            }
            else
            {
                if (numbers[i] > target)
                    continue;
            }
            
            for (var j = 0; j < i; j++)
            {
                if (numbers[i] + numbers[j] == target)
                    return new int[] { j + 1, i + 1 };
            }
        }
        
        return new int[] { 1, 2 };
    }
}