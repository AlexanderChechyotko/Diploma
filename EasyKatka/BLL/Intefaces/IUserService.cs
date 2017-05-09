using BLL.DTO;
using BLL.Infrastructure;
using Domain.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IUserService
    {
        Task<OperationDetails> Register(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        void SendEmail(string id, string title, string message);
        Task<ApplicationUser> FindByNameAsync(string name);
        Task<ApplicationUser> FindByIdAsync(string name);
        Task<bool> IsEmailConfirmedAsync(string id);
        Task<string> GeneratePasswordResetTokenAsync(string id);
        Task<bool> IsLockout(string name);
        Task<OperationDetails> ResetPassword(string email, string code, string password);
    }
}
