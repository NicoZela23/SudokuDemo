bool closeRequested = false;
while (!closeRequested)
{
NewPuzzle:

    Console.Clear();

    int?[,] generatedBoard = SudokuGenerator.Generate();
    int?[,] activeBoard = (int?[,])generatedBoard.Clone();
    MoveValidator validator = new MoveValidator(activeBoard, generatedBoard);
    SudokuConsoleWriter sudokuConsole = new SudokuConsoleWriter(activeBoard, generatedBoard);


    int x = 0;
    int y = 0;

    Console.Clear();

    while (!closeRequested && validator.ContainsNulls())
    {
        ShowGameInformation();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow: x = x <= 0 ? 8 : x - 1; break;
            case ConsoleKey.DownArrow: x = x >= 8 ? 0 : x + 1; break;
            case ConsoleKey.LeftArrow: y = y <= 0 ? 8 : y - 1; break;
            case ConsoleKey.RightArrow: y = y >= 8 ? 0 : y + 1; break;

            case ConsoleKey.D1: case ConsoleKey.NumPad1: activeBoard[x, y] = validator.IsValidMove(1, x, y) ? 1 : activeBoard[x, y]; break;
            case ConsoleKey.D2: case ConsoleKey.NumPad2: activeBoard[x, y] = validator.IsValidMove(2, x, y) ? 2 : activeBoard[x, y]; break;
            case ConsoleKey.D3: case ConsoleKey.NumPad3: activeBoard[x, y] = validator.IsValidMove(3, x, y) ? 3 : activeBoard[x, y]; break;
            case ConsoleKey.D4: case ConsoleKey.NumPad4: activeBoard[x, y] = validator.IsValidMove(4, x, y) ? 4 : activeBoard[x, y]; break;
            case ConsoleKey.D5: case ConsoleKey.NumPad5: activeBoard[x, y] = validator.IsValidMove(5, x, y) ? 5 : activeBoard[x, y]; break;
            case ConsoleKey.D6: case ConsoleKey.NumPad6: activeBoard[x, y] = validator.IsValidMove(6, x, y) ? 6 : activeBoard[x, y]; break;
            case ConsoleKey.D7: case ConsoleKey.NumPad7: activeBoard[x, y] = validator.IsValidMove(7, x, y) ? 7 : activeBoard[x, y]; break;
            case ConsoleKey.D8: case ConsoleKey.NumPad8: activeBoard[x, y] = validator.IsValidMove(8, x, y) ? 8 : activeBoard[x, y]; break;
            case ConsoleKey.D9: case ConsoleKey.NumPad9: activeBoard[x, y] = validator.IsValidMove(9, x, y) ? 9 : activeBoard[x, y]; break;

            case ConsoleKey.End: goto NewPuzzle;
            case ConsoleKey.Backspace: case ConsoleKey.Delete: activeBoard[x, y] = generatedBoard[x, y] ?? null; break;
            case ConsoleKey.Escape: closeRequested = true; break;
        }
    }

    if (!closeRequested)
    {
        ShowWinner();
    GetInput:
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Enter: break;
            case ConsoleKey.Escape:
                closeRequested = true;
                Console.Clear();
                break;
            default: goto GetInput;
        }
    }

    void ShowGameInformation()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Sudoku");
        Console.WriteLine();
        sudokuConsole.WriteToConsole();
        Console.WriteLine();
        Console.WriteLine("Press arrow keys to select a cell.");
        Console.WriteLine("Press 1-9 to insert values.");
        Console.WriteLine("Press [delete] or [backspace] to remove.");
        Console.WriteLine("Press [escape] to exit.");
        Console.WriteLine("Press [end] to generate a new sudoku.");
        Console.SetCursorPosition(y * 2 + 2 + (y / 3 * 2), x + 3 + +(x / 3));
    }
    void ShowWinner()
    {
        Console.Clear();
        Console.WriteLine("Sudoku");
        Console.WriteLine();
        sudokuConsole.WriteToConsole();
        Console.WriteLine();
        Console.WriteLine("You Win!");
        Console.WriteLine();
        Console.WriteLine("Play Again [enter], or quit [escape]?");
    }
}
Console.Clear();
Console.Write("Sudoku was closed.");
