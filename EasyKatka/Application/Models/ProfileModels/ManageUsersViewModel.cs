using Domain.Entities;
using System.Collections.Generic;

namespace Application.Models
{
    public class ManageUsersViewModel
    {
        public IList<ApplicationUser> Users { get; set; }
    }
}