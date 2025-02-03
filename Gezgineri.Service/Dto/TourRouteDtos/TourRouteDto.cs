using Gezgineri.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.TourRouteDtos
{
    public class TourRouteDto
    {
        public Guid? ID { get; set; }
        public Guid? TourId { get; set; }
        
        public string Location { get; set; }
        public int Order { get; set; }
        public DateTime Date { get; set; }
    }
}
