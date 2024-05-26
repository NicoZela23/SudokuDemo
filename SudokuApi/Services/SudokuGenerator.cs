using Towel;

namespace SudokuApi.Services
{


public static class SudokuGenerator
{
    // This function generates a Sudoku board with a specified number of blanks.
    public static int?[,] Generate(
        Random? randomNumberGenerator = null,
        int? numberOfBlanks = null)
    {
        randomNumberGenerator ??= Random.Shared;
        if (numberOfBlanks.HasValue && numberOfBlanks < 0 || 81 < numberOfBlanks)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfBlanks), numberOfBlanks.Value, $"{nameof(numberOfBlanks)} < 0 || 81 < {nameof(numberOfBlanks)}");
        }
        else if (!numberOfBlanks.HasValue)
        {
            numberOfBlanks = randomNumberGenerator.Next(0, 82);
        }

        // Initialize the Sudoku board
        int?[,] sudokuBoard = new int?[9, 9];
        (int[] Values, int Count)[,] validNumbers = new (int[] Values, int Count)[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                validNumbers[i, j] = (new int[9], -1);
            }
        }


        // This function updates the valid numbers for a given cell
        void UpdateValidNumbers(int row, int column)
        {
            NumberValidator validator = new NumberValidator(sudokuBoard);
            validNumbers[row, column].Count = 0;
            for (int i = 1; i <= 9; i++)
            {
                if (validator.IsNumberValidInSquare(i, row, column) &&
                    validator.IsNumberValidInRow(i, row, column) &&
                    validator.IsNumberValidInColumn(i, row, column))
                {
                    validNumbers[row, column].Values[validNumbers[row, column].Count++] = i;
                }
            }
        }


        // Fill the Sudoku board
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                UpdateValidNumbers(i, j);
                while (validNumbers[i, j].Count is 0)
                {
                    sudokuBoard[i, j] = null;
                    i = j is 0 ? i - 1 : i;
                    j = j is 0 ? 8 : j - 1;
                }
                int index = randomNumberGenerator.Next(0, validNumbers[i, j].Count);
                int value = validNumbers[i, j].Values[index];
                validNumbers[i, j].Values[index] = validNumbers[i, j].Values[validNumbers[i, j].Count - 1];
                validNumbers[i, j].Count--;
                sudokuBoard[i, j] = value;
            }
        }

        // Create blanks in the Sudoku board
        foreach (int i in randomNumberGenerator.NextUnique(Math.Max(1, numberOfBlanks.Value), 0, 81))
        {
            int row = i / 9;
            int column = i % 9;
            sudokuBoard[row, column] = null;
        }

        return sudokuBoard;
    }
}
}