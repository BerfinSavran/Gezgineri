

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class FavoritePlace : BaseEntity
    {
        [ForeignKey("PlaceId")]
        public Guid PlaceId { get; set; }
        [JsonIgnore]
        public Place? Place { get; set; }

        [ForeignKey("TravelerId")]
        public Guid TravelerId { get; set; }
        [JsonIgnore]
        public Traveler? Traveler { get; set; }
        public bool IsFavorite { get; set; } = false;

    }
}
