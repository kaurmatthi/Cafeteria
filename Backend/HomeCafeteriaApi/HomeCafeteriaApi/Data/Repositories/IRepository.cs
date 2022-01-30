using HomeCafeteriaApi.Models.DataModels;

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
}
