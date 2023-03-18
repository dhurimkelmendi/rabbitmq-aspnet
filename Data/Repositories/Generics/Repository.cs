using System.Collections.Generic;
using System.Threading.Tasks;
using HashApi.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HashApi.Data.Repositories.Generics
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        public HashApiDbContext _context;

        public Repository(HashApiDbContext contex)
        {
            _context = contex;
            DbSet = _context.Set<Tentity>();
        }
        public DbSet<Tentity> DbSet { get; }
        public Tentity Add(Tentity entity)
        {
            _context.Add(entity);
            Save();
            return entity;
        }
        public List<Tentity> AddRange(List<Tentity> entities)
        {
            _context.AddRange(entities);
            Save();

            return entities;
        }

        public async Task<IList<Tentity>> GetAllAsync()
        {
            return await _context.Set<Tentity>().AsNoTracking().ToListAsync();
        }

        public void Save() => _context.SaveChanges();

        Task<IList<Tentity>> IRepository<Tentity>.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
