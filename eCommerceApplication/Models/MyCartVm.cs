namespace eCommerceApplication.Models;

public class MyCartVm
{
    public int CartItemId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int Size { get; set; } = 7;
    public int Discount { get; set; }
    public double DiscountedAmount { get; set; }
    public DateTime CartDate
    {
        get; set;
    }
}
