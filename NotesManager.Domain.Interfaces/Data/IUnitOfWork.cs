using System;

namespace NotesManager.Domain.Interfaces.Data
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