using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}