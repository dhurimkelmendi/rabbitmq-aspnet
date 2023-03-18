using System.Linq;
using HashApi.Data.Entities;
using HashApi.Data.EntityFramework;
using HashApi.Data.Repositories.Generics;

namespace HashApi.Data.Repositories.Hashes
{
    public class HashRepository : Repository<Hash>, IHashRepository
    {
        public HashRepository(HashApiDbContext contex) : base(contex)
        {

        }

        public IQueryable<Hash> GetByDay(int days)
        {
            return DbSet.Take(days).AsQueryable();
        }
    }
}
