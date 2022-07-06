/*
135 Candy (Faster - WIP)

*/
public class Solution
{
    public int Candy(int[] ratings)
    {
        if (ratings.Length == 1)
            return 1;
        
        if (ratings.Length == 2)
        {
            if (ratings[0] != ratings[1])
                return 3;
            else
                return 2;
        }
        
        var candiesPerChildFromLeft = new int[ratings.Length];
        var candiesPerChildFromRight = new int[ratings.Length];
        
        for (var i = 0; i < ratings.Length; i++)
        {
            candiesPerChildFromLeft[i] = 1;
            
            if (i + 1 >= ratings.Length)
                break;

            candiesPerChildFromLeft[i] = ratings[i] > ratings[i + 1] ? candiesPerChildFromLeft[i] + 1 : 1;
        }
        
        for (var i = ratings.Length - 1; i >= 0; i--)
        {
            candiesPerChildFromRight[i] = 1;
            
            if (i - 1 < 0)
                break;

            candiesPerChildFromRight[i] = ratings[i] > ratings[i - 1] ? candiesPerChildFromRight[i] + 1 : 1;
        }
        
        var minCandies = 0;
        for (var x = 0; x < ratings.Length; x++)
        {
            minCandies += candiesPerChildFromRight[x] > candiesPerChildFromLeft[x] ? candiesPerChildFromRight[x] : candiesPerChildFromLeft[x];
        }
        
        return minCandies;
    }
}