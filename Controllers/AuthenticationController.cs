using System.Threading.Tasks;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace App.Controllers
{
    public class AuthenticationController : Controller
    {
        IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/login", Name = "login")]
        public async Task LoginAsync()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                  .WithRedirectUri(Url.RouteUrl(routeName: "profile") ?? "/profile")
                  .Build();

            await HttpContext.ChallengeAsync(
              Auth0Constants.AuthenticationScheme,
              authenticationProperties
            );
        }

        [HttpGet("/signup", Name = "signup")]
        public async Task SignUp()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                  .WithRedirectUri(Url.RouteUrl(routeName: "profile") ?? "/profile")
                  .WithParameter("screen_hint", "signup")
                  .Build();

            await HttpContext.ChallengeAsync(
              Auth0Constants.AuthenticationScheme,
              authenticationProperties
            );
        }

        [HttpGet("/logout", Name = "logout")]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                  .WithRedirectUri(Url.RouteUrl(routeName: "home") ?? "/")
                  .Build();

            await HttpContext.SignOutAsync(
              Auth0Constants.AuthenticationScheme,
              authenticationProperties
            );

            await HttpContext.SignOutAsync(
              CookieAuthenticationDefaults.AuthenticationScheme
            );
        }
    }
}
