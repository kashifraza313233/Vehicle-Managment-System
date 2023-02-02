

using System.ComponentModel.DataAnnotations;

namespace VM.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public int VId { get; set; }
    }
}
