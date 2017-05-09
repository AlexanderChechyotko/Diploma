using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
