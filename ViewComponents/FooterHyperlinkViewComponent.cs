using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class FooterHyperlinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string path, string text)
        {

            return View(new FooterHyperlinkModel
            {
                path = path,
                text = text
            });
        }
    }
}
