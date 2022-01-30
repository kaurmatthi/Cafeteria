using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels;

[Table("salesman_item")]
public class SalesmanItem : IdentifiedData
{
    public SalesmanItem(string salesmanId, string productInstanceId, string productTypeId)
    {
        SalesmanId = salesmanId;
        ProductInstanceId = productInstanceId;
        ProductTypeId = productTypeId;
    }
    [Column("salesman_id")]
    public string SalesmanId { get; set; }
    [Column("product_instance_id")]
    public string ProductInstanceId { get; set; }
    [Column("product_type_id")]
    public string ProductTypeId { get; set; }
}