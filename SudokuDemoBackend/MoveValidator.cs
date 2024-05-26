public class MoveValidator
{
    private int?[,] sudokuBoard;
    private int?[,] lockedSudokuBoard;

    public MoveValidator(int?[,] board, int?[,] lockedBoard)
    {
        this.sudokuBoard = board;
        this.lockedSudokuBoard = lockedBoard;
    }

    public bool IsValidMove(int value, int x, int y)
    {
        // Locked
        if (lockedSudokuBoard[x, y] is not null)
        {
            return false;
        }
        // Square
        for (int i = x - x % 3; i <= x - x % 3 + 2; i++)
        {
            for (int j = y - y % 3; j <= y - y % 3 + 2; j++)
            {
                if (sudokuBoard[i, j] == value)
                {
                    return false;
                }
            }
        }
        // Row
        for (int i = 0; i < 9; i++)
        {
            if (sudokuBoard[x, i] == value)
            {
                return false;
            }
        }
        // Column
        for (int i = 0; i < 9; i++)
        {
            if (sudokuBoard[i, y] == value)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsNulls()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuBoard[i, j] is null)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
