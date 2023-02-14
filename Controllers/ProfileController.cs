using System.Linq;
using System.Security.Claims;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public ViewResult Profile()
        {
            var profile = new UserProfile
            {
                nickname = User.Claims.FirstOrDefault(c => c.Type == "nickname")?.Value,
                name = User?.Identity?.Name,
                picture = User?.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                updated_at = User?.Claims.FirstOrDefault(c => c.Type == "updated_at")?.Value,
                email = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                email_verified = User?.Claims.FirstOrDefault(c => c.Type == "email_verified")?.Value.ToLower() == "true",
                sub = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value
            };

            ViewData["SerializedUserProfile"] = _jsonEncoder.Encode(profile);

            return View("Views/Pages/Profile.cshtml", profile);
        }
    }
}
