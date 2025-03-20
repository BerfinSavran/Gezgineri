
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class MyTravelPlan : BaseEntity
    {
        [ForeignKey("MyTravelId")]
        public Guid MyTravelId { get; set; }
        [JsonIgnore]
        public MyTravel? MyTravel { get; set; }

        [ForeignKey("PlaceId")]
        public Guid PlaceId { get; set; }
        [JsonIgnore]
        public Place? Place { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
    }
}
