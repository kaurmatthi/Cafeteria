using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels
{
    [Table("product_type")]
    public class ProductType : NamedData
    {
        public ProductType(string name, double price, string imageUrl) : base(name)
        {
            Price = price;
            ImageUrl = imageUrl;
        }
        [Column("price")]
        public double Price { get; set; }
        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}
