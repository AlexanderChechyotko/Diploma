using BLL.Services;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;

namespace BLL.Security
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            Configure(this);
        }

        private void Configure(ApplicationUserManager manager)
        {
            var provider = new DpapiDataProtectionProvider("Sample");

            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.RegisterTwoFactorProvider("EmailCode",
                new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "SecurityCode",
                    BodyFormat = "Your security code is {0}"
                }
            );

            manager.EmailService = new EmailService();
        }
    }
}
