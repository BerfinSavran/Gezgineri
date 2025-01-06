using Gezgineri.Entity.Types;
using System.ComponentModel.DataAnnotations;

namespace Gezgineri.Entity.Models
{
    public class Member: BaseEntity
    {
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public EnumRole Role { get; set; }

    }
}
