/*
36 Valid Sudoku (Faster)
Runtime: 147 ms, faster than 61.23% of C# online submissions for Valid Sudoku.
Memory Usage: 42.2 MB, less than 19.74% of C# online submissions for Valid Sudoku.
*/
public class Solution
{
    public static readonly Dictionary<string, int> SubBoxIndices = new Dictionary<string, int>
    {
        {"00", 0},
        {"01", 1},
        {"02", 2},
        {"10", 3},
        {"11", 4},
        {"12", 5},
        {"20", 6},
        {"21", 7},
        {"22", 8}
    };
    
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
                
                var boxGridIndex = SubBoxIndices[$"{x / 3}{y / 3}"];
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