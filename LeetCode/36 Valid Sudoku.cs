/*
36 Valid Sudoku
Runtime: 166 ms, faster than 42.27% of C# online submissions for Valid Sudoku.
Memory Usage: 41.6 MB, less than 59.37% of C# online submissions for Valid Sudoku.
*/
public class Solution
{
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
                    
                rowGrid[x, currentValueAsIndex] = true;
                
                if (colGrid[y, currentValueAsIndex])
                {
                    return false;
                }

                colGrid[y, currentValueAsIndex] = true;
                
                if (x <= 2)
                {
                    if (y <= 2)
                    {
                        if (boxGrid[0, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[0, currentValueAsIndex] = true;
                    }
                    else if (y >= 3 && y <= 5)
                    {
                        if (boxGrid[1, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[1, currentValueAsIndex] = true;
                    }
                    else
                    {
                        if (boxGrid[2, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[2, currentValueAsIndex] = true;
                    }
                }
                else if (x >= 3 && x <= 5)
                {
                    if (y <= 2)
                    {
                        if (boxGrid[3, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[3, currentValueAsIndex] = true;
                    }
                    else if (y >= 3 && y <= 5)
                    {
                        if (boxGrid[4, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[4, currentValueAsIndex] = true;
                    }
                    else
                    {
                        if (boxGrid[5, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[5, currentValueAsIndex] = true;
                    }
                }
                else
                {
                    if (y <= 2)
                    {
                        if (boxGrid[6, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[6, currentValueAsIndex] = true;
                    }
                    else if (y >= 3 && y <= 5)
                    {
                        if (boxGrid[7, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[7, currentValueAsIndex] = true;
                    }
                    else
                    {
                        if (boxGrid[8, currentValueAsIndex])
                        {
                            return false;
                        }

                        boxGrid[8, currentValueAsIndex] = true;
                    }
                }
            }
        }
        
        return true;
    }
}