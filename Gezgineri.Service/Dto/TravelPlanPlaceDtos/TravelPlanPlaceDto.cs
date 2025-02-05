using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.TravelPlanPlaceDtos
{
    public class TravelPlanPlaceDto
    {
        public Guid? ID { get; set; }
        public Guid? TravelPlanId { get; set; }
        public Guid? PlaceId { get; set; }
       
    }
}
