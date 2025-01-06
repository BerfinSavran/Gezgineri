using Gezgineri.Entity.Types;


namespace Gezgineri.Service.Dto.TravelerDtos
{
    public class UpdateTravelerDto
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public EnumGender Gender { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
