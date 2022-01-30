using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels;

[Table("product_instance")]
public class ProductInstance : IdentifiedData
{
    public ProductInstance(string productId)
    {
        ProductId = productId;
        State = ProductInstanceState.Available;
    }
    public string ProductId { get; set; }
    public ProductInstanceState State { get; set; }
}