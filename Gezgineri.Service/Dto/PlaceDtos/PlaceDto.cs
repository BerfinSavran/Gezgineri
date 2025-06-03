using Gezgineri.Entity.Types;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gezgineri.Service.Dto.PlaceDtos
{
    public class PlaceDto
    {
        public Guid? ID { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        public string? VisitDuration { get; set; }
        public double? EntryPrice { get; set; }
        public int? Capacity { get; set; }
        public EnumStatus Status { get; set; }
        public Guid? ApprovedById { get; set; }
    }
}
