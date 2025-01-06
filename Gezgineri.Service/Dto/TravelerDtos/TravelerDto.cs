using Gezgineri.Entity.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.TravelerDtos
{
    public class TravelerDto
    {
        public Guid ID { get; set; }
        public Guid MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
        public EnumGender Gender { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
