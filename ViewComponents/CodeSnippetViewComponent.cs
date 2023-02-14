using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class CodeSnippetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, string code)
        {
            return View(new CodeSnippetModel
            {
                title = title,
                code = code
            });
        }
    }
}
