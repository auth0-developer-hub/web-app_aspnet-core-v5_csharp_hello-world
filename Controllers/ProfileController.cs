using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProfileController : Controller
    {
        private IJsonEncoder _jsonEncoder;

        public ProfileController(IJsonEncoder jsonEncoder)
        {
            this._jsonEncoder = jsonEncoder;
        }

        [HttpGet("/profile", Name = "profile")]
        public ViewResult Profile()
        {
            var profile = new UserProfile
            {
                nickname = "Customer",
                name = "One Customer",
                picture = "https://cdn.auth0.com/blog/hello-auth0/auth0-user.png",
                updated_at = "2021-05-04T21:33:09.415Z",
                email = "customer@example.com",
                email_verified = false,
                sub = "auth0|12345678901234567890"
            };

            ViewData["SerializedUserProfile"] = _jsonEncoder.Encode(profile);

            return View("Views/Pages/Profile.cshtml", profile);
        }
    }
}
