using Gezgineri.Entity.Models;
using Gezgineri.Entity.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.PlaceDtos
{
    public class PlaceDto
    {
        public Guid? ID { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public string? ImageUrl { get; set; }
        public string? VisitDuration { get; set; }
        public double? EntryPrice { get; set; }
        public int? Capacity { get; set; }
        public bool IsFavorite { get; set; } = false;
        public EnumStatus Status { get; set; } = EnumStatus.Pending;
        public Guid? ApprovedById { get; set; }
    }
}
