using Gezgineri.Entity.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.OwnerDtos
{
    public class OwnerDto
    {
        public Guid ID { get; set; }
        public Guid MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
        public string BusinessName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LicenseNumber { get; set; }
    }
}
