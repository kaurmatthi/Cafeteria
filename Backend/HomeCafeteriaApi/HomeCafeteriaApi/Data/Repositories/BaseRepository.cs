using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories;

public class BaseRepository<TData> : IRepository<TData>
    where TData : class, IIdentifiedData
{
    internal HomeCafeteriaApiContext Context;
    internal DbSet<TData> Db;

    public BaseRepository(HomeCafeteriaApiContext context, DbSet<TData> db)
    {
        Context = context;
        Db = db;
    }
    public async Task<IEnumerable<TData>> Get()
        => await Db.ToListAsync();

    public async Task<TData?> Get(string id) 
        => await Db.FindAsync(id);

    public async Task Add(TData data)
    {
        Db.Add(data);
        await Context.SaveChangesAsync();

    }
    public async Task Update(TData data)
    {
        Db.Update(data);
        await Context.SaveChangesAsync();
    }

    public async Task Delete(TData data)
    {
        Db.Remove(data);
        await Context.SaveChangesAsync();
    }
}