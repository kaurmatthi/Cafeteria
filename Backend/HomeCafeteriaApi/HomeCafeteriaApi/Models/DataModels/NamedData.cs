using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels;

public abstract class NamedData : IdentifiedData
{
    protected NamedData(string name) =>
        Name = name;

    [Column("name")]
    public string Name { get; set; }
}