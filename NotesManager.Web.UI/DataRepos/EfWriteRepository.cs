using System.Collections.Generic;
using System.Data.Entity;
using NotesManager.Web.UI.DomainModels;

namespace NotesManager.Web.UI.DataRepos
{
    public class EfWriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public EfWriteRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        /// <summary>
        /// To be deleted with the specified entity. Warning: Will not remove any child objects and may ended up with ophen records
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted; //will not remove any child objects
        }

        /// <summary>
        /// o be deleted with the specified entity and its children. 
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void DeleteWithChildren(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

      
        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

    }
}