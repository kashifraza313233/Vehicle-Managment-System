using System.ComponentModel.DataAnnotations;

namespace VM.Data.Models
{
    public class VehicleInfo : BaseEntity
    {
        
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
        [Required]
        public string? Service_Type { get; set; } = string.Empty;

    }
}