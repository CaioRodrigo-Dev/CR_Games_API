using CR_Games_API___DTO.Request.User;
using CR_Games_API___Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CR_Games_API.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class UserController : Controller
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region EndPoints

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
        {
            try
            {
                var result = await _userService.CreateUser(request);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion


    }
}
