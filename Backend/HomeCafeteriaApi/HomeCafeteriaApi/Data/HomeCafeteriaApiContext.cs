#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeCafeteriaApi.Models;
using HomeCafeteriaApi.Models.DataModels;

namespace HomeCafeteriaApi.Data
{
    public class HomeCafeteriaApiContext : DbContext
    {
        public HomeCafeteriaApiContext (DbContextOptions<HomeCafeteriaApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProductType> Product { get; set; }
        public DbSet<ProductInstance> ProductInstances { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<SalesmanItem> SalesmenItems { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            var types = new List<ProductType>
            {
                new("Brownie", 0.65, "https://www.upload.ee/image/13840980/image1.jpg"),
                new("Muffin", 1, "https://www.upload.ee/image/13840982/image2.jpg"),
                new("Cake Pop", 1.35, "https://www.upload.ee/image/13840987/image3.jpg"),
                new("Apple tart", 1.50, "https://www.upload.ee/image/13840992/image4.jpg"),
                new("Water", 1.50, "https://www.upload.ee/image/13840993/image5.jpg"),
                new("Shirt", 2, "https://www.upload.ee/image/13840996/image6.jpg"),
                new("Pants", 3, "https://www.upload.ee/image/13840997/image7.png"),
                new("Jacket", 4, "https://www.upload.ee/image/13841000/image8.jpg"),
                new("Toy", 1, "https://www.upload.ee/image/13841001/image9.jpg")
            };

            mb.Entity<ProductType>().HasData(types);
                

            var instances = new List<ProductInstance>();

            for (var i = 0; i < 48; i++) instances.Add(new ProductInstance(types[0].Id));
            for (var i = 0; i < 36; i++) instances.Add(new ProductInstance(types[1].Id));
            for (var i = 0; i < 24; i++) instances.Add(new ProductInstance(types[2].Id));
            for (var i = 0; i < 60; i++) instances.Add(new ProductInstance(types[3].Id));
            for (var i = 0; i < 30; i++) instances.Add(new ProductInstance(types[4].Id));

            mb.Entity<ProductInstance>().HasData(instances);
            var salesman = new Salesman("User 1")
            {
                Id = "secret1"
            };
            var salesman2 = new Salesman("User 2")
            {
                Id = "secret2"
            };
            mb.Entity<Salesman>().HasData(salesman);
            mb.Entity<Salesman>().HasData(salesman2);
        }
    }
}
