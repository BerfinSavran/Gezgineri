using System.ComponentModel.DataAnnotations;

namespace Gezgineri.Entity.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

    }
}
