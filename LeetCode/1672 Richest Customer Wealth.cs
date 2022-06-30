/*
1672 Richest Customer Wealth
Runtime: 95 ms, faster than 87.54% of C# online submissions for Richest Customer Wealth.
Memory Usage: 39.4 MB, less than 5.57% of C# online submissions for Richest Customer Wealth.
*/
public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        var maxWealth = 0;
        for (var m = 0; m < accounts.Length; m++)
        {
            var customerWealth = 0;
            for (var n = 0; n < accounts[m].Length; n++)
            {
                customerWealth += accounts[m][n];
            }
            
            if (customerWealth > maxWealth)
                maxWealth = customerWealth;
        }
        
        return maxWealth;
    }
}