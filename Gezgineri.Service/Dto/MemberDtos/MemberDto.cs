
using Gezgineri.Entity.Types;
using System.ComponentModel.DataAnnotations;

namespace Gezgineri.Service.Dto.MemberDtos
{
    public class MemberDto
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}
