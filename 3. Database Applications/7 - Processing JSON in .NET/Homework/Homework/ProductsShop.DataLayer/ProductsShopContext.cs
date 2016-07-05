namespace ProductsShop.DataLayer
{
    using ProductsShop.DataLayer.Migrations;
    using ProductsShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SellerId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}