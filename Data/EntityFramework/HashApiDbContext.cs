using Microsoft.EntityFrameworkCore;

namespace HashApi.Data.EntityFramework
{
    public class HashApiDbContext : DbContext
    {
        public HashApiDbContext(DbContextOptions<HashApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HashApiDbContext).Assembly);
        }
    }
}
