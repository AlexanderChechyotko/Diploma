using BLL.DTO;
using BLL.Infrastructure;
using BLL.Intefaces;
using BLL.Security;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class UserService : IUserService
    {
        private const string RegisterSuccessMessage = "Регистрация успешно пройдена";
        private const string UserWithThisLoginAlreadyExistMessage = "Пользователь с таким логином уже существует";
        private const string UserNotFound = "Пользователь не найден";
        private const string PasswordSuccessChanged = "Пароль успешно изменён";
        private const string IncorrectCode = "Неправильный код";

        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public UserService(
            ApplicationRoleManager roleManager,
            ApplicationUserManager userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<OperationDetails> Register(UserDTO userDTO)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser {
                    Email = userDTO.Email,
                    UserName = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    DateOfBirth = userDTO.DateOfBirth,
                    PhoneNumber = userDTO.PhoneNumber,
                    Bids = userDTO.Bids
                };
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await _userManager.AddToRoleAsync(user.Id, userDTO.Role);

                return new OperationDetails(true, RegisterSuccessMessage, "");
            }

            return new OperationDetails(false, UserWithThisLoginAlreadyExistMessage, "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _userManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
            {
                claim = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }

        public void SendEmail(string id, string title, string message)
        {
             _userManager.SendEmail(id, title, message);
        }

        public async Task<ApplicationUser> FindByNameAsync(string name)
        {
             return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> IsEmailConfirmedAsync(string id)
        {
            return await _userManager.IsEmailConfirmedAsync(id);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string id)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(id);
        }

        public async Task<OperationDetails> ResetPassword(string email, string code, string password)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return new OperationDetails(false, UserNotFound, "password");
            }
            var result = await _userManager.ResetPasswordAsync(user.Id, code, password);
            if (result.Succeeded)
            {
                return new OperationDetails(true, PasswordSuccessChanged, "password");
            }
            return new OperationDetails(false, IncorrectCode, "password");
        }

        public async Task<bool> IsLockout(string name)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(name);
            return await _userManager.IsLockedOutAsync(user.Id);
        }

        public async Task<ApplicationUser> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}