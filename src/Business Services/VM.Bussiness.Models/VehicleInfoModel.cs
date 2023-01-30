using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VM.Bussiness.Models
{
    public class VehicleInfoModel
    {

        [Key]
        public int VId { get; set; }
        [Required]
        public string? Vehicle { get; set; } = string.Empty;
        [Required]
        public String? VehicleModel { get; set; } = string.Empty;
        [Required]
        public String? VehicleNumber { get; set; } = string.Empty;
        [Required]
        public string? OwnerName { get; set; } = string.Empty;
        [Required]
        public string? ContactNo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; } = string.Empty;
        [Display(Name = "Services")]
        public virtual int ServicesId { get; set; }

        [ForeignKey("ServicesId")]
        public virtual Services? Services { get; set; }

    }
}