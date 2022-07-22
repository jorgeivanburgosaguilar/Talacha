/*
36 Valid Sudoku (WIP)

0 | 0 1 2 | 3 4 5 | 6 7 8
1 | 0 1 2 | 3 4 5 | 6 7 8
2 | 0 1 2 | 3 4 5 | 6 7 8
-------------------------
3 | 0 1 2 | 3 4 5 | 6 7 8
4 | 0 1 2 | 3 4 5 | 6 7 8
5 | 0 1 2 | 3 4 5 | 6 7 8
--------------------------
6 | 0 1 2 | 3 4 5 | 6 7 8
7 | 0 1 2 | 3 4 5 | 6 7 8
8 | 0 1 2 | 3 4 5 | 6 7 8
*/
public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        for (var i = 0; i < 9; i++)
        {
            var verticalLine = new bool[9];
            for (var j = 0; j < 9; j++)
            {
                var currentChar = board[j][i];
                if (currentChar == '.')
                    continue;
                
                var index = Convert.ToInt32(currentChar.ToString()) - 1;
                if (verticalLine[index])
                    return false;
                
                verticalLine[index] = true;
            }
            
            var horizontalLine = new bool[9];
            for (var j = 0; j < 9; j++)
            {
                var currentChar = board[i][j];
                if (currentChar == '.')
                    continue;
                
                var index = Convert.ToInt32(currentChar.ToString()) - 1;
                if (horizontalLine[index])
                    return false;
                
                horizontalLine[index] = true;
            }
            
            // ToDo Check Horizontal and Vertical per 3x3
        }
        
        return true;
    }
}