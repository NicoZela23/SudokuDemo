using System;

namespace SudokuApi.Services
{
    public class SudokuBoardService
    {
        private int?[,] _sudokuBoard;
        private int?[,] originalBoardValues;

        public int?[,] GetBoard()
        {
            return _sudokuBoard;
        }

        public void GenerateBoard()
        {
            if (_sudokuBoard == null)
            {
                _sudokuBoard = SudokuGenerator.Generate();
                originalBoardValues = (int?[,])_sudokuBoard.Clone();
            }
        }

        public int?[] GetRow(int rowIndex)
        {
            if (_sudokuBoard == null)
            {
                throw new InvalidOperationException("Sudoku board has not been generated yet.");
            }

            int cols = _sudokuBoard.GetLength(1);
            int?[] row = new int?[cols];
            for (int j = 0; j < cols; j++)
            {
                row[j] = _sudokuBoard[rowIndex, j];
            }
            return row;
        }
        public bool UpdateBoard(int x, int y, int value)
        {
            if (_sudokuBoard == null)
            {
                throw new InvalidOperationException("Sudoku board has not been generated yet.");
            }

            MoveValidator validator = new MoveValidator(_sudokuBoard, originalBoardValues);
            if (validator.IsValidMove(value, x, y))
            {
                _sudokuBoard[x, y] = value;
                return true;
            }
            return false;
        }
        public bool ClearCell(int x, int y)
        {
            if (_sudokuBoard == null)
            {
                throw new InvalidOperationException("Sudoku board has not been generated yet");
            }

            if (originalBoardValues[x,y] != null)
            {
                return false;
            }

            _sudokuBoard[x,y] = null;
            return true;
        }
    }
}
