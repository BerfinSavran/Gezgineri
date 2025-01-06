using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class Owner : BaseEntity
    {
        [ForeignKey("MemberId")]
        public Guid MemberId { get; set; }
        [JsonIgnore]
        public Member? Member { get; set; }
        public string BusinessName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LicenseNumber { get; set; }
    }
}
