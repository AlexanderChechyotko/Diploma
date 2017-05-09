using BLL.DTO;
using BLL.Infrastructure;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IProfileService
    {
        Task<UserDTO> GetUserProfile(string name);
        Task<OperationDetails> EditProfile(UserDTO user, string name);
        IList<ApplicationUser> GetUserList();
        Task<OperationDetails> ChangePassword(string id, string oldPassword, string newPassword);
        Task<OperationDetails> LockoutUser(string email);
        Task<OperationDetails> ResetUserPassword(string email);
    }
}
