
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class TravelPlan : BaseEntity
    {
        [ForeignKey("MyTravelId")]
        public Guid MyTravelId { get; set; }
        [JsonIgnore]
        public MyTravel? MyTravel { get; set; }

        public DateTime Date { get; set; }

    }
}
