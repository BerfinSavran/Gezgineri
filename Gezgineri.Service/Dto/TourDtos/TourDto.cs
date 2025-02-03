using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.TourDtos
{
    public class TourDto
    {
        public Guid? ID { get; set; }
        public Guid? AgencyId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Pending;
        public Guid? ApprovedById { get; set; }
    }
}
