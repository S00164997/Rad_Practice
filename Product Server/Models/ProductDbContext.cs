using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Product_Server.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}