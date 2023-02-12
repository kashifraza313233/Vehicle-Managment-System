using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VM.Bussiness.Models
{
    public class AddServicesModel
    {
        [Required]
        [Display(Name = "Choose Image")]
        public IFormFile Coverimage { get; set; }
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
