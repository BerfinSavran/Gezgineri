
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class MyTravel : BaseEntity
    {
        [ForeignKey("TravelerId")]
        public Guid TravelerId { get; set; }
        [JsonIgnore]
        public Traveler? Traveler { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
