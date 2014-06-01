using System.Collections.Generic;

namespace NotesManager.Domain.Interfaces
{
    public interface IWriteRepository<TEntity>
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWithChildren(TEntity entity);
    }
}