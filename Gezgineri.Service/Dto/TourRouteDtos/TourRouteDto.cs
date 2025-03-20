

namespace Gezgineri.Service.Dto.TourRouteDtos
{
    public class TourRouteDto
    {
        public Guid? ID { get; set; }
        public Guid? TourId { get; set; }
        public string Location { get; set; }
        public int Order { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
