using System.Threading.Tasks;
using App.Models;

namespace App.Services
{
    public interface IMessageService
    {
        Message GetPublicMessage();
        Message GetProtectedMessage();
        Task<ApiResponse> GetAdminMessage(string accessToken);
    }
}
