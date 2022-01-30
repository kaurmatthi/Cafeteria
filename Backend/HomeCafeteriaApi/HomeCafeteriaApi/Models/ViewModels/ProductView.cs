namespace HomeCafeteriaApi.Models.ViewModels;

public class ProductView
{
    public ProductView(string productId, string name, int quantity, string imageUrl, double price)
    {
        ProductId = productId;
        Name = name;
        Quantity = quantity;
        ImageUrl = imageUrl;
        Price = price;
    }
    public string ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
}