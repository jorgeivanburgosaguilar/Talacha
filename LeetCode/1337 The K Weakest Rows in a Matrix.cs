/*
1337 The K Weakest Rows in a Matrix
Runtime: 298 ms, faster than 7.87% of C# online submissions for The K Weakest Rows in a Matrix.
Memory Usage: 45.5 MB, less than 22.15% of C# online submissions for The K Weakest Rows in a Matrix.
*/
public class Solution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var listSumSoldiersInRow = new Dictionary<int, int>();
        for (var i = 0; i < mat.Length; i++)
        {
            var sumSoldiers = 0;
            for (var j = 0; j < mat[i].Length; j++)
            {
                sumSoldiers += mat[i][j];
            }
            
            listSumSoldiersInRow.Add(i, sumSoldiers);
        }
        
        // TODO: Tratar de usar SortedList, esto debe ser muy lento por culpa del Dictionary y LINQ
        var sortedListSumSoldiersInRow = listSumSoldiersInRow.OrderBy(v => v.Value);
        var indices = new int[k];
        for (var y = 0; y < k; y++)
        {
            indices[y] = sortedListSumSoldiersInRow.ElementAt(y).Key;
        }
        
        return indices;
    }
}