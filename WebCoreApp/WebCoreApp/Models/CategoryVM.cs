using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApp.Models
{
    public class CategoryVM
    {
        [Required]
        public string Name { get; set; }
    }
}
