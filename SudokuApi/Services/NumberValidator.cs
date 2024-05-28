public class NumberValidator
{
    private int?[,] sudokuBoard;

    public NumberValidator(int?[,] board)
    {
        this.sudokuBoard = board;
    }

    // Check if a number is valid in the current 3x3 square
    public bool IsNumberValidInSquare(int number, int row, int column)
    {
        for (int i = row - row % 3; i <= row; i++)
        {
            for (int j = column - column % 3; j <= column - column % 3 + 2 && !(i == row && j == column); j++)
            {
                if (sudokuBoard[i, j] == number)
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Check if a number is valid in the current row
    public bool IsNumberValidInRow(int number, int row, int column)
    {
        for (int i = 0; i < column; i++)
        {
            if (sudokuBoard[row, i] == number)
            {
                return false;
            }
        }
        return true;
    }

    // Check if a number is valid in the current column
    public bool IsNumberValidInColumn(int number, int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            if (sudokuBoard[i, column] == number)
            {
                return false;
            }
        }
        return true;
    }
}
