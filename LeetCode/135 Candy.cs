/*
135 Candy
SIN RESOLVER
*/
public class ListRating
{
    public int Rating { get; set; }
    public int Candy { get; set; }
    public ListRating NextRating { get; set; }
    
    public ListRating(int rating)
    {
        this.Rating = rating;
        this.Candy = 0;
        this.NextRating = null;
    }
}

public class Solution
{
    public static ListRating ConvertToLinkedList(int[] ratings)
    {
        ListRating lastRating = null;
        
        for (var i = ratings.Length - 1; i >= 0; i--)
        {
            var temp = new ListRating(ratings[i]);
            temp.NextRating = lastRating;
            lastRating = temp;
        }
        
        return lastRating;
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
        
        var ratingList = ConvertToLinkedList(ratings);
        while (ratingList.NextRating != null)
        {
            
        }
        
        var minNumberCandies = 0;
        var previousCandy = 0;
        
        for (var i = 0; i < ratings.Length; i++)
        {
            if (i == ratings.Length - 1)
                break;
            
            if (i == 0)
            {
                minNumberCandies += ratings[i] == ratings[i + 1]  ? 2 : 3;
                previousCandy = ratings[i] >= ratings[i + 1] ? 1 : 2;
            }
            else
            {        
                if (ratings[i] == ratings[i + 1])
                {
                    minNumberCandies += 1;
                }
                else if (ratings[i] < ratings[i + 1])
                {
                    minNumberCandies += previousCandy + 1;
                    previousCandy++;
                }
                else // if (ratings[i] > ratings[i + 1])
                {
                    if (previousCandy == 1)
                        minNumberCandies += 1;
                    else
                        minNumberCandies += previousCandy + 1;
                    
                    previousCandy = 1;
                }
            }
        }
        
        return minNumberCandies;
    }
}