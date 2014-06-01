using System.Collections.Generic;

namespace NotesManager.Web.UI.DomainModels
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