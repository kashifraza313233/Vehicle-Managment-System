using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace VM.Bussiness.Models
{
    public class AddServicesModel
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [Display(Name = "Choose Image")]
        public IFormFile? CoverImage { get; set; }
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
