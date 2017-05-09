using Application.Models;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Intefaces;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ProfileController : BaseController
    {
        private IProfileService _profileService;
        private IUserService _userService;

        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
           var userDTO = await _profileService.GetUserProfile(AuthenticationManager.User.Identity.Name);

            ProfileViewModel model = new ProfileViewModel
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                PhoneNumber = userDTO.PhoneNumber
            };
            
            return View(model);
        }

        public PartialViewResult ChangePassword()
        {
            return PartialView("_ChangePasswordPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            string oldPass = model.OldPassword;
            string newPass = model.NewPassword;
            string confirmPass = model.ConfirmPassword;

            if (newPass == confirmPass)
            {
                OperationDetails details = await _profileService.ChangePassword(AuthenticationManager.User.Identity.Name, oldPass, newPass);

                if (details.Succedeed)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public async Task<PartialViewResult> EditProfile()
        {
            var userDTO = await _profileService.GetUserProfile(AuthenticationManager.User.Identity.Name);

            ProfileViewModel model = new ProfileViewModel
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                PhoneNumber = userDTO.PhoneNumber
            };

            return PartialView("_EditProfilePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(ProfileViewModel model)
        {
            UserDTO userDTO = new UserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth=model.DateOfBirth,
                PhoneNumber = model.PhoneNumber
            };

            OperationDetails result = await _profileService.EditProfile(userDTO, 
                AuthenticationManager.User.Identity.Name);
            if (result.Succedeed)
            {
                return View("Index", model);
            }

            return View("Error");
        }

        [Authorize(Roles = "admin")]
        public PartialViewResult ManageUsers()
        {
            ManageUsersViewModel model = new ManageUsersViewModel();
            model.Users = _profileService.GetUserList();

            return PartialView("_ManageUsersPartial", model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> LockoutUser(string email)
        {
            var result = await _profileService.LockoutUser(email);
            if (result.Succedeed)
            {
                return View("Index");
            }
            ModelState.AddModelError(result.Property, result.Message);
            return View("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ResetUserPassword(string email)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileService.ResetUserPassword(email);
                if (!result.Succedeed)
                {
                    ModelState.AddModelError(result.Property, result.Message);
                    return RedirectToAction("Index");
                }
                var user = await _userService.FindByNameAsync(email);
                if (user == null)
                {
                    return View("Index");
                }
                string code = await _userService.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { code = code }, protocol: Request.Url.Scheme);
                _userService.SendEmail(user.Id, "Сброс пароля", "Для сброса пароля, перейдите по ссылке <a href=\"" + callbackUrl + "\">сбросить</a>");
            }
            return RedirectToAction("Index");
        }
    }
}