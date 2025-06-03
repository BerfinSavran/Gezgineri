using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gezgineri.Entity.Models
{
    public class Admin : BaseEntity
    {
        [ForeignKey("MemberId")]
        public Guid MemberId { get; set; }
        [JsonIgnore]
        public Member? Member { get; set; }

    }
}
