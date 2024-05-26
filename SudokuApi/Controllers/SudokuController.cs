using Microsoft.AspNetCore.Mvc;
using SudokuApi.DTO;
using SudokuApi.Services;

namespace SudokuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SudokuController : ControllerBase
    {
        private readonly SudokuBoardService _sudokuBoardService;

        public SudokuController(SudokuBoardService sudokuBoardService)
        {
            _sudokuBoardService = sudokuBoardService;
        }

        [HttpGet]
        public ActionResult<int?[][]> Get()
        {
            _sudokuBoardService.GenerateBoard();
            var sudokuBoard = _sudokuBoardService.GetBoard();
            var jaggedArray = JaggedArray.ConvertToJaggedArray(sudokuBoard);
            return Ok(jaggedArray);
        }

        [HttpGet("{rowIndex}")]
        public ActionResult<int?[]> GetRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= 9)
            {
                return BadRequest("Row index must be between 0 and 8.");
            }

            try
            {
                var row = _sudokuBoardService.GetRow(rowIndex);
                return Ok(row);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public ActionResult UpdateBoard([FromBody] MoveRequest request)
        {
            if (request.X < 0 || request.X >= 9 || request.Y < 0 || request.Y >= 9 || request.Value < 1 || request.Value > 9)
            {
                return BadRequest("Invalid coordinates or value.");
            }

            bool isValidMove = _sudokuBoardService.UpdateBoard(request.X, request.Y, request.Value);

            if (isValidMove)
            {
                return Ok("Value updated successfully.");
            }
            else
            {
                return BadRequest("Invalid move.");
            }
        }
    }
}
