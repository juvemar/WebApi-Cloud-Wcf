using SourceControlSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SourceControlSystem.Data
{
    public interface ISourceControlSystemDbContext
    {
        IDbSet<Commit> Commits { get; set; }

        IDbSet<SoftwareProject> SoftwareProjects { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
