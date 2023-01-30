using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Data.Models
{
    public class Services
    {
        [Key]
        public int ServicesId { get; set; }

        [Required]
        public string ServicesType { get; set; }=string.Empty;
    }
}
