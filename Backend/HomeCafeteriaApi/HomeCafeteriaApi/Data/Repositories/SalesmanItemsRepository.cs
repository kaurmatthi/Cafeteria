using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories;

public class SalesmanItemsRepository : BaseRepository<SalesmanItem>
{
    public SalesmanItemsRepository(HomeCafeteriaApiContext context, DbSet<SalesmanItem> db) : base(context, db) { }
}