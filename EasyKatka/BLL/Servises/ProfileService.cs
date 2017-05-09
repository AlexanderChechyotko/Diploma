using BLL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Security;
using BLL.Infrastructure;
using Domain.Entities;

namespace BLL.Servises
{
    public class ProfileService : IProfileService
    {
        private const string ProfileSuccessEdit = "Регистрация успешно пройдена";
        private const string SomethingWrong = "Что-то пошло не так";
        private const string UserNotFound = "Пользователь не найден";
        private const string SuccessPasswordChanged = "Пароль успешно изменён";
        private const string ErrorResetPassword = "Не удалось сбросить пароль";
        private const string SuccessResetPassword = "Пароль был сброшен";
        private const string SuccessLockoutUser = "Пароль был сброшен";
        private const string PasswordsDoNotMatch = "Пароли не совпадают";

        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public ProfileService(
            ApplicationRoleManager roleManager,
            ApplicationUserManager userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<OperationDetails> EditProfile(UserDTO userDTO, string name)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(name);
            if (user != null)
            {
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.DateOfBirth = userDTO.DateOfBirth;
                user.PhoneNumber = userDTO.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new OperationDetails(true, ProfileSuccessEdit, "");
                }
            }
            return new OperationDetails(false, SomethingWrong, "");
        }

        public async Task<UserDTO> GetUserProfile(string name)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(name);
            UserDTO userDTO = new UserDTO();
            if (user != null)
            {
                userDTO.Email = user.Email;
                userDTO.FirstName = user.FirstName;
                userDTO.LastName = user.LastName;
                userDTO.DateOfBirth = user.DateOfBirth;
                userDTO.PhoneNumber = user.PhoneNumber;
            }

            return userDTO;
        }

        public IList<ApplicationUser> GetUserList()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        public async Task<OperationDetails> ChangePassword(string id, string oldPassword, string newPassword)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(id);
            if (user == null)
            {
                return new OperationDetails(false, UserNotFound, "password");
            }
            var result = await _userManager.RemovePasswordAsync(user.Id);
            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(user.Id, newPassword);
                if (result.Succeeded)
                {
                    return new OperationDetails(true, SuccessPasswordChanged, "password");
                }
            }
            return new OperationDetails(false, PasswordsDoNotMatch, "password");
        }

        public async Task<OperationDetails> LockoutUser(string email)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                user.LockoutEnabled = true;
                user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(42);
                await _userManager.UpdateAsync(user);

                return new OperationDetails(true, SuccessLockoutUser, "");
            }

            return new OperationDetails(false, UserNotFound, "");
        }

        public async Task<OperationDetails> ResetUserPassword(string email)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return new OperationDetails(false, UserNotFound, "password");
            }
            var result = await _userManager.RemovePasswordAsync(user.Id);
            if (!result.Succeeded)
            {
                return new OperationDetails(false, ErrorResetPassword, "");
            }
            return new OperationDetails(true, SuccessResetPassword, "");
        }
    }
}
