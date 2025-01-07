using Microsoft.AspNetCore.Mvc;

namespace CR_Games_API.Controllers.Base
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
