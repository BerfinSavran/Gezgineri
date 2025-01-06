using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Dto.AgencyDtos
{
    public class UpdateAgencyDto
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebSiteUrl { get; set; }
        public string? TaxNumber { get; set; }
        public string? LicenseNumber { get; set; }
    }
}
