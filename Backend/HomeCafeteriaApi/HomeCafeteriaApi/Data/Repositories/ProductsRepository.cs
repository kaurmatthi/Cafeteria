using HomeCafeteriaApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeteriaApi.Data.Repositories;

public class ProductsRepository : BaseRepository<ProductType>
{
    public ProductsRepository(HomeCafeteriaApiContext context, DbSet<ProductType> db) 
        : base(context, db) {}
}