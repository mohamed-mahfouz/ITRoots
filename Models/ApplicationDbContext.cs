using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
           : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }


    }
}