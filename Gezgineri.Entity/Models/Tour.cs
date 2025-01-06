
using Gezgineri.Entity.Types;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class Tour : BaseEntity
    {
        [ForeignKey("AgencyId")]
        public Guid AgencyId { get; set; }
        [JsonIgnore]
        public Agency? Agency { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Pending;

        [ForeignKey("ApprovedById")]
        public Guid? ApprovedById { get; set; }
        [JsonIgnore]
        public Member? ApprovedBy { get; set; }

    }
}
