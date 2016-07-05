using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.ConsoleClient
{
    class ProductsShopMain
    {
        static void Main()
        {
            var context = new ProductsShop.DataLayer.ProductsShopContext();
            Console.WriteLine(context.Users.Count());
        }
    }
}
