using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.DataModels.Enums;

namespace Services.DataModels
{
    public class Journal :Product
    {
        [Required]
        public DateTime PrintDate { get; set; }
        [Required]
        public Topic Topic { get; set; }
    }
}
