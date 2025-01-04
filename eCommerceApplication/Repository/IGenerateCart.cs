using eCommerceApplication.Models;

namespace eCommerceApplication.Repository;

public interface IGenerateCart
{
    Task<int> GenerateNewCart(int customerId);
    Task<List<MyCartVm>> GetCartItems(int cartId);
}