using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
           : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserActivation> UsersActivation { get; set; }


    }
}