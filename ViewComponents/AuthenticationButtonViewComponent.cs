using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class AuthenticationButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(bool isAuthenticated)
        {
            return View(new AuthenticationButtonModel
            {
                isAuthenticated = isAuthenticated
            });
        }
    }
}
