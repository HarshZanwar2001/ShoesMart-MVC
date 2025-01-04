using eCommerceApplication.Models;
using eCommerceApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApplication.Areas.Categories.Controllers;
[Area("Categories")]
public class HomeController : Controller
{
    private readonly ICommonRepository<Category> _categoryReop;

    public HomeController(ICommonRepository<Category> categoryReop)
    {
        _categoryReop = categoryReop;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryReop.GetAllAsync();
        ViewBag.PageTitle = "Welcome To eCommerce Categories Section!";
        return View(categories);
    }
    
}
