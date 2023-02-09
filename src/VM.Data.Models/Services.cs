using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VM.Data.Models
{
    public class Services
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [Display(Name = "Choose Image")]
        //public IFormFile CoverPhoto { get; set; }
        public string CoverImage { get; set; } = string.Empty;
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
