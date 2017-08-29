using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Content
{
    
    public class EFContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public EFContext()
            : base ("Asp_Net_MVC_CS")
        {

        }
    }
}