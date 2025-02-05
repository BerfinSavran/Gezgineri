using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.MyTravelDtos
{
    public class MyTravelDto
    {
        public Guid? ID { get; set; }
        public Guid? TravelerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
