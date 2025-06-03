using Gezgineri.Entity.Types;


namespace Gezgineri.Service.Dto.TourDtos
{
    public class ToursWithIncludeDto
    {
        public Guid? ID { get; set; }
        public Guid? AgencyId { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? WebSiteUrl { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Pending;
        public Guid? ApprovedById { get; set; }
    }
}
