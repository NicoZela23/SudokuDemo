public class SudokuConsoleWriter
{
    private int?[,] sudokuBoard;
    private int?[,] lockedSudokuBoard;

    public SudokuConsoleWriter(int?[,] board, int?[,] lockedBoard)
    {
        this.sudokuBoard = board;
        this.lockedSudokuBoard = lockedBoard;
    }

    public void WriteToConsole()
    {
        ConsoleColor consoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("╔═══════╦═══════╦═══════╗");
        for (int i = 0; i < 9; i++)
        {
            Console.Write("║ ");
            for (int j = 0; j < 9; j++)
            {
                if (lockedSudokuBoard is not null && lockedSudokuBoard[i, j] is not null)
                {
                    Console.Write((lockedSudokuBoard[i, j].HasValue ? lockedSudokuBoard[i, j].ToString() : "■") + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write((sudokuBoard[i, j].HasValue ? sudokuBoard[i, j].ToString() : "■") + " ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                if (j is 2 || j is 5)
                {
                    Console.Write("║ ");
                }
            }
            Console.WriteLine("║");
            if (i is 2 || i is 5)
            {
                Console.WriteLine("╠═══════╬═══════╬═══════╣");
            }
        }
        Console.WriteLine("╚═══════╩═══════╩═══════╝");
        Console.ForegroundColor = consoleColor;
    }
}
