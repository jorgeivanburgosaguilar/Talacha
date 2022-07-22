/*
135 Candy (Faster)
Runtime: 132 ms, faster than 77.26% of C# online submissions for Candy.
Memory Usage: 41.5 MB, less than 96.75% of C# online submissions for Candy.
*/
public class Solution
{
    public int Candy(int[] ratings)
    {
        var ratingsLength = ratings.Length;
        if (ratingsLength == 1)
        {
            return 1;
        }
        
        if (ratingsLength == 2)
        {
            return ratings[0] != ratings[1] ? 3 : 2;
        }
        
        var candiesPerChildFromLeft = new int[ratingsLength];
        var candiesPerChildFromRight = new int[ratingsLength];
        
        candiesPerChildFromLeft[0] = 1;
        for (var i = 1; i < ratingsLength; i++)
        {
            candiesPerChildFromLeft[i] = 1;
            candiesPerChildFromLeft[i] = ratings[i] > ratings[i - 1] ? candiesPerChildFromLeft[i - 1] + 1 : candiesPerChildFromLeft[i];
        }
        
        candiesPerChildFromRight[ratingsLength - 1] = 1;
        for (var i = ratingsLength - 2; i >= 0; i--)
        {
            candiesPerChildFromRight[i] = 1;
            candiesPerChildFromRight[i] = ratings[i] > ratings[i + 1] ? candiesPerChildFromRight[i + 1] + 1 : candiesPerChildFromRight[i];
        }
        
        var minCandies = 0;
        for (var x = 0; x < ratingsLength; x++)
        {
            minCandies += candiesPerChildFromRight[x] > candiesPerChildFromLeft[x] ? candiesPerChildFromRight[x] : candiesPerChildFromLeft[x];
        }
        
        return minCandies;
    }
}