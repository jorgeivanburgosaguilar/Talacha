/*
1342 Number of Steps to Reduce a Number to Zero
Runtime: 30 ms, faster than 62.89% of C# online submissions for Number of Steps to Reduce a Number to Zero.
Memory Usage: 25.3 MB, less than 30.91% of C# online submissions for Number of Steps to Reduce a Number to Zero.
*/
public class Solution
{
    public int NumberOfSteps(int num)
    {
        if (num == 0)
            return 0;
        
        var steps = 0;
        while (num > 0)
        {
            num = num % 2 == 0 ? num / 2 : num - 1;
            steps++;
        }
        return steps;
    }
}