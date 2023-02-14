using System.Collections.Generic;
using App.Models.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new FooterModel
            {
                links = new List<FooterHyperlinkModel>{
                new FooterHyperlinkModel {
                    path = "https://auth0.com/why-auth0/",
                    text =  "Why Auth0",
                },
                new FooterHyperlinkModel {
                    path = "https://auth0.com/docs/get-started",
                    text =  "How It Works",
                },
                new FooterHyperlinkModel {
                    path = "https://auth0.com/blog/developers/",
                    text =  "Developer Blog",
                },
                new FooterHyperlinkModel {
                    path = "https://auth0.com/contact-us",
                    text =  "Contact an Expert",
                },
            }
            });
        }
    }
}
