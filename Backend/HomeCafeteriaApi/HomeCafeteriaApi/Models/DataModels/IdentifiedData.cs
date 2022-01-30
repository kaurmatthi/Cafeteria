using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels;

public abstract class IdentifiedData : IIdentifiedData
{
    protected IdentifiedData() 
        => Id = Guid.NewGuid().ToString();

    [Column("id")]
    public string Id { get; set; }
}

public interface IIdentifiedData
{
    public string Id { get; set; }
}