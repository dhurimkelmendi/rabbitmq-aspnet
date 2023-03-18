using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashApi.Data.Repositories.Generics
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Tentity Add(Tentity entity);
        List<Tentity> AddRange(List<Tentity> entities);
        Task<IList<Tentity>> GetAllAsync();

    }
}
