/*
167 Two Sum II - Input Array Is Sorted (Faster)
Runtime: 268 ms, faster than 21.65% of C# online submissions for Two Sum II - Input Array Is Sorted.
Memory Usage: 44.8 MB, less than 72.70% of C# online submissions for Two Sum II - Input Array Is Sorted.
*/
public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        if (numbers.Length == 2)
            return new int[] { 1, 2 };
        
        var indexAdd = 0;
        var indexSubstract = numbers.Length - 1;
        var result = numbers[indexAdd] + numbers[indexSubstract];
            
        while (result != target)
        {
            if (result > target)
                indexSubstract--;
            else
                indexAdd++;
            
            result = numbers[indexAdd] + numbers[indexSubstract];
        }
        
        return new int[] { indexAdd + 1, indexSubstract + 1 };
    }
}