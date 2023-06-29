/*
135 Candy
Runtime: 2281 ms, faster than 5.05% of C# online submissions for Candy.
Memory Usage: 42.1 MB, less than 47.87% of C# online submissions for Candy.
*/
public class Solution
{
    public static void CheckNeighborsFromIndex(int fromIndex, int[] ratings, ref int[] candiesPerChild)
    {
        for (var i = fromIndex; i >= 0; i--)
        {
            // Check After
            if (i == candiesPerChild.Length - 1)
            {
                if (ratings[i] > ratings[i - 1] && candiesPerChild[i] <= candiesPerChild[i - 1])
                {
                    candiesPerChild[i] = candiesPerChild[i - 1] + 1;
                }
            }
            else
            {
                if (ratings[i] < ratings[i + 1] && candiesPerChild[i] >= candiesPerChild[i + 1])
                {
                    candiesPerChild[i + 1] = candiesPerChild[i] - 1;
                }
            }
            
            // Check Before
            if (i == 0)
            {
                if (ratings[i] > ratings[i + 1] && candiesPerChild[i] <= candiesPerChild[i + 1])
                {
                    candiesPerChild[i] = candiesPerChild[i + 1] + 1;
                }
            }
            else
            {
                if (ratings[i] < ratings[i - 1] && candiesPerChild[i] >= candiesPerChild[i - 1])
                {
                    candiesPerChild[i - 1] = candiesPerChild[i] + 1;
                }
            }
        }
    }
    
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
        
        var candiesPerChild = new int[ratings.Length];
        for (var i = 0; i < ratings.Length; i++)
        {
            if (i == 0)
            {
                candiesPerChild[i] = 1;
            }
            else if (ratings[i] == ratings[i - 1])
            {
                candiesPerChild[i] = 1;
            }
            else if (ratings[i - 1] > ratings[i])
            {
                candiesPerChild[i] = 1;
                CheckNeighborsFromIndex(i, ratings, ref candiesPerChild);
            }
            else // if (ratings[i - 1] < ratings[i])
            {
                candiesPerChild[i] = candiesPerChild[i - 1] + 1;
            }
        }
        
        return candiesPerChild.Sum(); // ToDo Faster Sum than LINQ
    }
}