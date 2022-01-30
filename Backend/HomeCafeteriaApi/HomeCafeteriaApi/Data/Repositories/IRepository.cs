using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories
{
    public interface IRepository<TData>
    where TData : class, IIdentifiedData
    {
        Task<IEnumerable<TData>> Get();
        Task<TData?> Get(string id);
        Task Add(TData data);
        Task Update(TData data);
        Task Delete(TData data);
    }

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
    public class ProductsRepository : BaseRepository<ProductType>
    {
        public ProductsRepository(HomeCafeteriaApiContext context, DbSet<ProductType> db) 
            : base(context, db) {}
    }
    public class ProductInstancesRepository : BaseRepository<ProductInstance>
    {
        public ProductInstancesRepository(HomeCafeteriaApiContext context, DbSet<ProductInstance> db) : base(context, db) { }
    }
    public class SalesmenRepository : BaseRepository<Salesman>
    {
        public SalesmenRepository(HomeCafeteriaApiContext context, DbSet<Salesman> db) : base(context, db) { }
    }

    public class SalesmanItemsRepository : BaseRepository<SalesmanItem>
    {
        public SalesmanItemsRepository(HomeCafeteriaApiContext context, DbSet<SalesmanItem> db) : base(context, db) { }
    }
}
