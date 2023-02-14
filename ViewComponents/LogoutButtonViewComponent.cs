using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class LogoutButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
