using System.Text.Json.Serialization;

namespace HomeCafeteriaApp.Models;

public class SalesmanView
{
    [JsonPropertyName("salesmanId")]
    public string SalesmanId { get; set; }
    [JsonPropertyName("salesmanName")]
    public string SalesmanName { get; set; }
    [JsonPropertyName("items")]
    public List<ProductView> Items { get; set; }
    [JsonPropertyName("productCount")] 
    public int ProductCount { get; set; }
}