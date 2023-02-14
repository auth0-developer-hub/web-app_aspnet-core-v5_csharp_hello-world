using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class Auth0FeatureViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string resourceUrl, string icon, string title, string description)
        {
            var model = new Auth0FeatureModel
            {
                resourceUrl = resourceUrl,
                icon = icon,
                title = title,
                description = description
            };

            return View(model);
        }
    }
}
