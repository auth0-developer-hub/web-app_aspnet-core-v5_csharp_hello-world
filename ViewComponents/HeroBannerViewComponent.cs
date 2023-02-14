using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class HeroBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
