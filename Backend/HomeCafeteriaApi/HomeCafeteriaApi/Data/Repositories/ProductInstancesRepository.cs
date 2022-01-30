using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories;

public class ProductInstancesRepository : BaseRepository<ProductInstance>
{
    public ProductInstancesRepository(HomeCafeteriaApiContext context, DbSet<ProductInstance> db) : base(context, db) { }

    public async Task AddRange(IEnumerable<ProductInstance> data)
    {
        Db.AddRange(data);
        await Context.SaveChangesAsync();

    }
}