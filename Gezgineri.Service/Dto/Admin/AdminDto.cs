using Gezgineri.Entity.Types;
using System;


namespace Gezgineri.Service.Dto.Admin
{
    public class AdminDto
    {
        public Guid ID { get; set; }
        public Guid MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}
