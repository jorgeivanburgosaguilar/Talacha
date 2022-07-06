/*
135 Candy (Version para Depurador)
*/
using System;
using System.Linq;

public class Solution
{
    public static void CheckNeighborsFromIndex(int fromIndex, int[] ratings, ref int[] candiesPerChild)
    {
        Console.WriteLine("From Index {0}:", fromIndex);
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
    
    public static int Candy(int[] ratings)
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
            
            Console.WriteLine("Vuelta {0} (Rating: {1})", i, ratings[i]);
            foreach (var children in candiesPerChild)
                Console.WriteLine(children);
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
        for (var x = 0; x < ratings.Length; x++)
        {
            Console.WriteLine("Rating {0}, Candies: {1}", ratings[x], candiesPerChild[x]);
        }
        
        return candiesPerChild.Sum();
    }
    
    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Debe dar 5: {0}", Candy(new int[] { 3,2,3 }));
        Console.WriteLine();
        Console.WriteLine("Debe dar 11: {0}", Candy(new int[] { 1,3,4,5,2 }));
        Console.WriteLine();
        Console.WriteLine("Debe dar 12: {0}", Candy(new int[] { 5,4,3,2,3 }));
        Console.WriteLine();
        Console.WriteLine("Debe dar 14: {0}", Candy(new int[] { 4,3,9,9,9,2,1,2 }));
        Console.WriteLine();
        Console.WriteLine("Debe dar 22: {0}", Candy(new int[] { 4,3,2,1,2,2,2,3,4,2,1 }));
    }
}