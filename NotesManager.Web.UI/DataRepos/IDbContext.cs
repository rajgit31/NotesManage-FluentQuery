using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NotesManager.Web.UI.DataRepos
{
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Sets this instance. 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);

        Database Database { get; set; }
    }
}