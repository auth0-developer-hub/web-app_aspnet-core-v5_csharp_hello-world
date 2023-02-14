using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IJsonEncoder _jsonEncoder;

        public MessageController(IMessageService messageService, IJsonEncoder jsonEncoder)
        {
            this._messageService = messageService;
            this._jsonEncoder = jsonEncoder;
        }

        [HttpGet("/public", Name = "public_message")]
        public ViewResult PublicMessage()
        {
            ViewData["MessageType"] = "Public";
            ViewData["Description"] = "<strong>Any visitor can access this page.</strong>";

            ViewData["Response"] = _jsonEncoder.Encode(_messageService.GetPublicMessage());

            return View("Views/Pages/Message.cshtml");
        }

        [HttpGet("/protected", Name = "protected_message")]
        [Authorize]
        public ViewResult ProtectedMessage()
        {
            ViewData["MessageType"] = "Protected";
            ViewData["Description"] = "<strong>Only authenticated users can access this page.</strong>";

            ViewData["Response"] = _jsonEncoder.Encode(_messageService.GetProtectedMessage());

            return View("Views/Pages/Message.cshtml");
        }

        [HttpGet("/admin", Name = "admin_message")]
        [Authorize]
        public async Task<ViewResult> AdminMessage()
        {
            ViewData["MessageType"] = "Admin";
            ViewData["Description"] = @"<strong>
                Only authenticated users with the <code>read:admin-messages</code> permission should access this page.
            </strong>";

            var token = await GetAccessToken();
            var message = await _messageService.GetAdminMessage(token);

            ViewData["Response"] = _jsonEncoder.Encode(message.IsSuccessful() ? message.message : message.error);

            return View("Views/Pages/Message.cshtml");
        }

        private async Task<string> GetAccessToken()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            return token;
        }
    }
}
