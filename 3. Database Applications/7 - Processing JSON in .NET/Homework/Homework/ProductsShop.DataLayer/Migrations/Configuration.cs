namespace ProductsShop.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.DataLayer.ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsShop.DataLayer.ProductsShopContext";
        }

        protected override void Seed(ProductsShop.DataLayer.ProductsShopContext context)
        {
        }
    }
}
