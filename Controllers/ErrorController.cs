using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public ViewResult Index()
        {
            var contextFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (contextFeature != null)
            {
                ViewData["Error"] = "Internal Server Error";
                ViewData["Description"] = contextFeature.Error.Message;
                HttpContext.Response.StatusCode = 500;
            }
            else if (HttpContext.Response.StatusCode == 404)
            {
                ViewData["Error"] = "Not Found";
            }

            return View("Views/Pages/Error.cshtml");
        }
    }
}
