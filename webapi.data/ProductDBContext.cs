using System.Data.Entity;
using webapi.core.Entities;
using System;
namespace webapi.data
{
    public class ProductDBContext:DbContext
    {
        public ProductDBContext() : base("ProductDBContext") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOption>().HasRequired<Product>(a => a.Product)
                .WithMany(a => a.ProductOptions)
                .HasForeignKey<Guid>(a => a.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
