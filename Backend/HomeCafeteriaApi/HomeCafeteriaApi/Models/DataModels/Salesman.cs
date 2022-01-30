using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeteriaApi.Models.DataModels;

[Table("salesman")]
public class Salesman : NamedData
{
    public Salesman(string name) : base(name) {}
}