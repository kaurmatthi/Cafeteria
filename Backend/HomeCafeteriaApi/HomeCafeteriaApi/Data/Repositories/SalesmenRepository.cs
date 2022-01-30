using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories;

public class SalesmenRepository : BaseRepository<Salesman>
{
    public SalesmenRepository(HomeCafeteriaApiContext context, DbSet<Salesman> db) : base(context, db) { }
}