namespace SudokuApi.Services
{
    public static class JaggedArray
    {
        public static int?[][] ConvertToJaggedArray(int?[,] twoDimensionalArray)
        {
            int rows = twoDimensionalArray.GetLength(0);
            int cols = twoDimensionalArray.GetLength(1);
            int?[][] jaggedArray = new int?[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int?[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }
}
