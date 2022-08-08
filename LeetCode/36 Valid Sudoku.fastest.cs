/*
36 Valid Sudoku (Fastest)
Runtime: 111 ms, faster than 95.65% of C# online submissions for Valid Sudoku.
Memory Usage: 41.6 MB, less than 72.42% of C# online submissions for Valid Sudoku.
*/
public class Solution
{
    public static int GetSubBoxIndex(int x, int y)
    {
        var resultX = x / 3;
        var resultY = y / 3;
        
        if (resultX == 0)
        {
            if (resultY == 0)
            {
                return 0;
            }
            else if (resultY == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        else if (resultX == 1)
        {
            if (resultY == 0)
            {
                return 3;
            }
            else if (resultY == 1)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }
        else
        {
            if (resultY == 0)
            {
                return 6;
            }
            else if (resultY == 1)
            {
                return 7;
            }
            else
            {
                return 8;
            }
        }
        
        return -1;
    }
    
    public bool IsValidSudoku(char[][] board)
    {
        var rowGrid = new bool[9, 9];
        var colGrid = new bool[9, 9];
        var boxGrid = new bool[9, 9];
        
        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {   
                var currentValue = board[x][y];
                if (currentValue == '.')
                {
                    continue;
                }
                
                int currentValueAsIndex = currentValue - '1';
                if (rowGrid[x, currentValueAsIndex])
                {
                    return false;
                }
                
                if (colGrid[y, currentValueAsIndex])
                {
                    return false;
                }
                
                var boxGridIndex = GetSubBoxIndex(x, y);
                if (boxGrid[boxGridIndex, currentValueAsIndex])
                    return false;
                
                rowGrid[x, currentValueAsIndex] = true;
                colGrid[y, currentValueAsIndex] = true;
                boxGrid[boxGridIndex, currentValueAsIndex] = true;
            }
        }
        
        return true;
    }
}