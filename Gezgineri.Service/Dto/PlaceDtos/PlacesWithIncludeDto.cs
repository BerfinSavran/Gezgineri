using Gezgineri.Entity.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.PlaceDtos
{
    public class PlacesWithIncludeDto
    {
        public Guid? ID { get; set; }
        public Guid? OwnerId { get; set; }
        public string BusinessName { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        public string? VisitDuration { get; set; }
        public double? EntryPrice { get; set; }
        public int? Capacity { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Pending;
        public Guid? ApprovedById { get; set; }
    }
}
