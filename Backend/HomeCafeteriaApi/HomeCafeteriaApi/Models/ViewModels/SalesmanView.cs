namespace HomeCafeteriaApi.Models.ViewModels;

public class SalesmanView
{
    public SalesmanView(string salesmanId, string salesmanName, List<ProductView> items, int productCount)
    {
        SalesmanId = salesmanId;
        SalesmanName = salesmanName;
        Items = items;
        ProductCount = productCount;
    }
    public string SalesmanId { get; set; }
    public string SalesmanName { get; set; }
    public List<ProductView> Items { get; set; }
    public int ProductCount { get; set; }
}