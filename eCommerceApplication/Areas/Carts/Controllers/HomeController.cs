using eCommerceApplication.Models;
using eCommerceApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApplication.Areas.Carts.Controllers;

[Area("Carts")]
public class HomeController : Controller
{
    private readonly ICommonRepository<Cart> _cartRepository;
    private readonly ICommonRepository<CartItem> _cartItemRepository;
    private readonly IGenerateCart _generateCart;
    public HomeController(ICommonRepository<CartItem> cartItemRepository, IGenerateCart generateCart, ICommonRepository<Cart> cartRepository)
    {
        _cartItemRepository = cartItemRepository;
        _generateCart = generateCart;
        _cartRepository = cartRepository;
    }


    public async Task<IActionResult> YourCart()
    {
        var myCartItems = await _generateCart.GetCartItems(Convert.ToInt32(HttpContext.Session.GetInt32("CartId")));
        return View(myCartItems);
    }
    public async Task<IActionResult> AddToCart(int productId, int customerId = 1)
    {
        HttpContext.Session.SetInt32("CustomerId", 1);
        if (HttpContext.Session.GetInt32("CartId") == null || HttpContext.Session.GetInt32("CartId") <= 0)
        {
            await _generateCart.GenerateNewCart(customerId);
            var carts = await _cartRepository.GetAllAsync();
            HttpContext.Session.SetInt32("CartId", carts.OrderByDescending(c => c.CartId).First().CartId);
        }
        int result = await _cartItemRepository.InsertAsync(new CartItem() { CartId = Convert.ToInt32(HttpContext.Session.GetInt32("CartId")), ProductId = productId, Quantity = 1 });
        if (result > 0)
        {
            return RedirectToAction("YourCart");
        }
        return View();
    }
}