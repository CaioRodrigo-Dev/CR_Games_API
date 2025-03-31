//using CR_Games_API___Service.Interfaces;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;

//namespace CR_Games_API.Controllers
//{
//    [ApiController]
//    [Route("Controller")]
//    public class ConsolesController : Controller
//    {
//        #region Fields
//        private readonly IConsolesService _consolesService;
//        #endregion

//        #region Constructor
//        public ConsolesController(IConsolesService consolesService)
//        {
//            _consolesService = consolesService;
//        }
//        #endregion

//        #region EndPoints
//        [HttpPost("AddConsole")]
//        public async Task<IActionResult> AddConsole([FromBody] AddConsoleRequestDTO request)
//        {
//            try
//            {
//                var result = await _consolesService.AddConsole(request);
//                return new JsonResult(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        #endregion
//    }
//}
