namespace eCommerceApplication.Models;

public class Cart
{
    public int CartId { get; set; }
    public DateTime CartDate { get; set; }
    public int? CustomerId { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
