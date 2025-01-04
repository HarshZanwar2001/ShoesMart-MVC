using eCommerceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApplication.Repository;

public class ECommerceDbContext:DbContext
{
    public ECommerceDbContext()
    {
        
    }
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Port=3306;Database=ecomerce;User=root;Password=root;",
                serverVersion,
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5, // Number of retry attempts
                    maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum delay between retries
                    errorNumbersToAdd: null // Additional error codes to retry
                ));
        }
    }


}
