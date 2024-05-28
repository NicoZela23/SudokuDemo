namespace SudokuApi.DTO
{
    public class MoveRequest
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
}
