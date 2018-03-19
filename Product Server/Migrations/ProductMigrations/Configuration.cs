namespace Product_Server.Migrations.ProductMigrations
{
    using Product_Server.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Product_Server.Models.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ProductMigrations";
        }

        protected override void Seed(Product_Server.Models.ProductDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Suppliers.AddOrUpdate(s => s.Name,
                new Supplier[] {
                    new Supplier { Name="Tool Man", Address="123 the Beaches"  },
                    new Supplier { Name="Hardware Man", Address="1 the Brook"  },
                    new Supplier { Name="Plumber Man", Address="Unit 12 Ballymun"  }
                });
            context.SaveChanges();
            Random r = new Random();
            context.Products.AddOrUpdate(s => s.Description,
                new Product[] {
                    new Product{  Description="9 inch Nails", SupplierID = GetRandomSupplierID(context), Price = 0.20f, Quantity = r.Next(100,200) },
                    new Product{  Description="Size 9 shoe", SupplierID = GetRandomSupplierID(context), Price = 22.10f, Quantity = r.Next(10,15) },
                    new Product{  Description="Large Overalls", SupplierID = GetRandomSupplierID(context), Price = 42.10f, Quantity = r.Next(10,15) },
                    new Product{  Description="Draining Boards", SupplierID = GetRandomSupplierID(context), Price = 142.10f, Quantity = r.Next(5,7) },
                });
            context.SaveChanges();

        }

        private int GetRandomSupplierID(ProductDbContext Context)
        {
            return Context.Suppliers.Select(s => new { s.ID, order = Guid.NewGuid() })
                                    .OrderBy(o => o.order)
                                    .Select(s => s.ID)
                                    .First();
        }

    }
    }

