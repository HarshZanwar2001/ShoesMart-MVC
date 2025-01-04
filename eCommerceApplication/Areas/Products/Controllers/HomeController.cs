using eCommerceApplication.Models;
using eCommerceApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApplication.Areas.Products.Controllers;
[Area("Products")]
public class HomeController : Controller
{
    private readonly ICommonRepository<Product> _productRepository;

    public HomeController(ICommonRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
        var products=await _productRepository.GetAllAsync();
        ViewBag.PageTitle = "Infoway Products List!";
        return View(products);
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productRepository.GetDetailsAsync(id);
        return View(product);
    }
    public async Task<IActionResult> CategoryWiseProducts(int id)
    {
        var products = await _productRepository.GetAllAsync();
        ViewBag.PageTitle = "Infoway Products List!";
        return View("Index",products.Where(p=>p.CategoryId==id));
    }
}
