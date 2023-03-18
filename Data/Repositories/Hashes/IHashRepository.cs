using System.Linq;
using HashApi.Data.Entities;
using HashApi.Data.Repositories.Generics;

namespace HashApi.Data.Repositories.Hashes
{
    public interface IHashRepository : IRepository<Hash>
    {
        IQueryable<Hash> GetByDay(int days);
    }
}
