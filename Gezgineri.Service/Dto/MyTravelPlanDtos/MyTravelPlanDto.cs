using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.MyTravelPlanDtos
{
    public class MyTravelPlanDto
    {
        public Guid? ID { get; set; }
        public Guid MyTravelId { get; set; }
        public Guid PlaceId { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
    }
}
