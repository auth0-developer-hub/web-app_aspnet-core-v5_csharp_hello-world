using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class LoginButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
