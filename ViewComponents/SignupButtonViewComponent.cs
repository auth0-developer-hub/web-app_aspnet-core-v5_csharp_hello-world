using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class SignupButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
