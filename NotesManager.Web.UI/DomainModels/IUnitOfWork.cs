using System;

namespace NotesManager.Web.UI.DomainModels
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}