using System.Text.Json.Serialization;

namespace HomeCafeteriaApp.Models
{
    public class ProductView
    {
        [JsonPropertyName("productId")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("price")] 
        public double Price { get; set; }
    }
}
