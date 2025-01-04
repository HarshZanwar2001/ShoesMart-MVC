
using eCommerceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApplication.Repository;

public class GenerateCart : IGenerateCart
{
    private readonly ECommerceDbContext _dbContext;

    public GenerateCart(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GenerateNewCart(int customerId)
    {
        string query = $"select NewCartFunc({customerId},curdate())";
        return await _dbContext.Database.ExecuteSqlRawAsync(query);
    }

    public async Task<List<MyCartVm>> GetCartItems(int cartId)
    {
        var result = from cart in _dbContext.Carts
                     join
                     cartItem in _dbContext.CartItems
                     on cart.CartId equals cartItem.CartId
                     where cart.CartId == cartId
                     join
                     product in _dbContext.Products
                     on cartItem.ProductId equals product.ProductId
                     select new MyCartVm { CartDate = cart.CartDate, CartItemId = cartItem.CartItemId, Discount = product.Discount, ProductName = product.ProductName, UnitPrice = product.UnitPrice, DiscountedAmount = product.UnitPrice - ((product.UnitPrice * product.Discount) / 100), Quantity = 1, Size = 7 };
        return await result.ToListAsync();
    }
}
