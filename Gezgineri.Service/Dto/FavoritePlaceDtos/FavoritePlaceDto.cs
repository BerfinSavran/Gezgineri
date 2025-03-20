

namespace Gezgineri.Service.Dto.FavoritePlaceDtos
{
    public class FavoritePlaceDto
    {
        public Guid? ID { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? TravelerId { get; set; }
        public bool IsFavorite { get; set; } = false;
    }
}
