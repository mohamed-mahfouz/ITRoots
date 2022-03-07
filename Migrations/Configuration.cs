namespace ITRoots.Migrations
{
    using ITRoots.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITRoots.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1 , Name = "Cheese Cake",Price=50.95m},
                new Product() { Id = 2, Name = "Molten Cake", Price = 60.40m },
                new Product() { Id = 3, Name = "Ice Cream", Price = 30m },
                new Product() { Id = 4, Name = "Fruit Salad", Price = 70.80m },
                new Product() { Id = 5, Name = "Latte", Price = 25m },
                new Product() { Id = 6, Name = "Espresso", Price = 30m },
                new Product() { Id = 7, Name = "Cola", Price = 20m },
                new Product() { Id = 8, Name = "Pepsi", Price = 20m },
                new Product() { Id = 9, Name = "Tea", Price = 10m },
                new Product() { Id = 10, Name = "Orange Juice", Price = 30.66m }
                );

            context.Roles.AddOrUpdate(r => r.Id,
                new Role () { Id = Guid.NewGuid(),RoleName = "Admin"},
                new Role() { Id = Guid.NewGuid(), RoleName = "User" }
                );
        }
    }
}
