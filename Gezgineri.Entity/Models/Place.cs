
using Gezgineri.Entity.Types;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class Place : BaseEntity
    {
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        [JsonIgnore]
        public Owner? Owner { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public string? ImageUrl { get; set; }
        public string? VisitDuration { get; set; }
        public double? EntryPrice { get; set; }
        public int? Capacity { get; set; }
        public bool IsFavorite { get; set; } = false;
        public EnumStatus Status { get; set; } = EnumStatus.Pending;

        [ForeignKey("ApprovedById")]
        public Guid? ApprovedById { get; set; }
        [JsonIgnore]
        public Member? ApprovedBy { get; set; }
    }
}
