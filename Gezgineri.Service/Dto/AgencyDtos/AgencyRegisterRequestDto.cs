using System.ComponentModel.DataAnnotations;

namespace Gezgineri.Service.Dto.AgencyDtos
{
    public class AgencyRegisterRequestDto
    {
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string? TaxNumber { get; set; }
        public string? LicenseNumber { get; set; }
    }
}
