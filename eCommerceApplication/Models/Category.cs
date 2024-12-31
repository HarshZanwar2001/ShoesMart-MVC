using System.ComponentModel.DataAnnotations;

namespace eCommerceApplication.Models;

public class Category
{
    public int CategoryId { get; set; }
    [MaxLength(100)]
    [Required(ErrorMessage = "Produt Name is a required field!")]
    public string CategoryName { get; set; } = string.Empty;
    [MaxLength(400)]
    [Required(ErrorMessage = "Produt Name is a required field!")]
    public string Description { get; set; }=string.Empty;

    public ICollection<Product>? Products { get; set; }
}
