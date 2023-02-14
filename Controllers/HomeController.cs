using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("/", Name = "home")]
        public ViewResult Index()
        {
            return View("Views/Pages/Home.cshtml");
        }
    }
}
