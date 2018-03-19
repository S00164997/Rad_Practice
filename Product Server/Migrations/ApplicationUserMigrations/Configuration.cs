namespace Product_Server.Migrations.ApplicationUserMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Product_Server.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Product_Server.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationUserMigrations";
        }

        protected override void Seed(Product_Server.Models.ApplicationDbContext context)
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
            var manager =
                 new UserManager<ApplicationUser>(
                     new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Purchases Manager" });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "fflynstone",
                    Email = "Flintstone.fred@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = new PasswordHasher().HashPassword("Flint$12345"),
                    
                    FirstName = "Fred",//property
                    SecondName = "Flinstone",
                }
                );

            context.SaveChanges();
            var fred = manager.FindByName("fflynstone");
            manager.AddToRole(fred.Id, "Purchases Manager");
            context.SaveChanges();

        }
    }
}
