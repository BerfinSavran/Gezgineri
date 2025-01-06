using Gezgineri.Entity.Types;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class Traveler : BaseEntity
    {
        [ForeignKey("MemberId")]
        public Guid MemberId { get; set; }

        [JsonIgnore]
        public Member? Member { get; set; }
        public EnumGender Gender { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
