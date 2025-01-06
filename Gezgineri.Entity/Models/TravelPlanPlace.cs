
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class TravelPlanPlace : BaseEntity
    {
        [ForeignKey("TravelPlanId")]
        public Guid TravelPlanId { get; set; }
        [JsonIgnore]
        public TravelPlan? TravelPlan { get; set; }

        [ForeignKey("PlaceId")]
        public Guid PlaceId { get; set; }
        [JsonIgnore]
        public Place? Place { get; set; }
    }
}
