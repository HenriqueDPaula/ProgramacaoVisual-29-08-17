using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}