using CR_Games_API___DTO.Request.Games;
using CR_Games_API___Service.Interfaces;
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
                return BadRequest(new { Message = ex.Message });
            }

        }
        #endregion
    }
}
