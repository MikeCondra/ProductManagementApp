using Microsoft.EntityFrameworkCore;
using ProductManagementApp;

namespace ProductManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool doSave = true;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;",
                ServerVersion.AutoDetect("Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;")
            );

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                // CREATE: Add a new product
                context.Products.Add(new Product { Name = "Laptop", Price = 999.99m });
                if (doSave) context.SaveChanges();

                // READ: Retrieve and display all products
                Console.WriteLine("Products in the Database:");
                var products = context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }
                if (doSave) context.SaveChanges();

                // UPDATE: Update the price of the first product
                var productToUpdate = context.Products.First();
                productToUpdate.Price = 1200.99m;
                if (doSave) context.SaveChanges();

                // DELETE: Remove the first product
                var productToDelete = context.Products.First();
                context.Products.Remove(productToDelete);
                if (doSave) context.SaveChanges();

                // READ: Retrieve and display all products again
                Console.WriteLine("Products in the Database:");
                var updatedProducts = context.Products.ToList();
                foreach (var product in updatedProducts)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }
                if (doSave) context.SaveChanges();
            }
        }
    }
}