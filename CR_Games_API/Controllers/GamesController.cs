using CR_Games_API___DTO.Request.Games;
using CR_Games_API___DTO.Response.Games;
using CR_Games_API___Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CR_Games_API.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class GamesController : Controller
    {
        #region Fields
        private readonly IGamesService _gamesService;
        #endregion

        #region Constructor
        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
        #endregion

        #region Endpoints
        [HttpPost("AddGame")]
        public async Task<IActionResult> AddGame([FromBody] AddGameRequestDTO request)
        {
            try
            {
                var result = await _gamesService.AddGame(request);
                return new JsonResult(result);
            }

        catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage  = ex.Message });
            }

        }

        [HttpGet("GetGameById")]
        public async Task<IActionResult> GetGameById([FromQuery] GetGameByIdRequestDTO request)
        {
            try
            {
                var game = await _gamesService.GetGameById(request);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteGameById")]
        public async Task<IActionResult> DeleteGameById (DeleteGameByIdRequestDTO request)
        {
            try
            {
                await _gamesService.DeleteGameById(request);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateGame")]
        public async Task<IActionResult> UpdateGame([FromBody]UpdateGameRequestDTO request)
        {
            try
            {
                var updatedGame = await _gamesService.UpdateGame(request);
                if (updatedGame == null)
                    throw new Exception("Game não encontrado");
                return Ok("Informações do Game atualizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}
