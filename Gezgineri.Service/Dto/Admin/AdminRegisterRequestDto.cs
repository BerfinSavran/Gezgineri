using System.ComponentModel.DataAnnotations;

namespace Gezgineri.Service.Dto.Admin
{
    public class AdminRegisterRequestDto
    {
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
