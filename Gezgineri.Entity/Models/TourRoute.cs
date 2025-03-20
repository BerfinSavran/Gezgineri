
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class TourRoute : BaseEntity
    {
        [ForeignKey("TourId")]
        public Guid TourId { get; set; }
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public string Location { get; set; }
        public int Order { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

    }
}
