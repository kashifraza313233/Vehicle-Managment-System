using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Bussiness.Models
{
    public class ServicesModel
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [Display(Name ="Choose Image")]
        public IFormFile CoverPhoto { get; set; }
        public string Coverimage { get; set; }
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        


    }
}
