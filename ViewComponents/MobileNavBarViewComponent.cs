using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class MobileNavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string activeRoute)
        {
            return View(new NavBarModel(activeRoute));
        }
    }
}
