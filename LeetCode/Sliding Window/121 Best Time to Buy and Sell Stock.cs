/*
121 Best Time to Buy and Sell Stock
Runtime: 231 ms, faster than 98.06% of C# online submissions for Best Time to Buy and Sell Stock.
Memory Usage: 49.5 MB, less than 11.60% of C# online submissions for Best Time to Buy and Sell Stock.
*/
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var pricesLength = prices.Length;
        var buy = 0;
        var sell = 1;
        var maxProfit = 0;

        while (sell < pricesLength)
        {
            var priceBuy = prices[buy];
            var priceSell = prices[sell];

            if (priceSell < priceBuy )
            {
                buy = sell;
            }

            maxProfit = Math.Max(maxProfit, priceSell - priceBuy);
            sell++;
        }

        return maxProfit;
    }
}