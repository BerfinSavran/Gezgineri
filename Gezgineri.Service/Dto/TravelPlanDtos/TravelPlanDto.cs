using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.TravelPlanDtos
{
    public class TravelPlanDto
    {
        public Guid? ID { get; set; }
        public Guid MyTravelId { get; set; }
        public DateTime Date { get; set; }
    }
}
