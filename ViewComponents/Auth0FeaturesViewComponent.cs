using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class Auth0FeaturesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
