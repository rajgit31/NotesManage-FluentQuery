using System.Collections.Generic;

namespace NotesManager.Domain.Interfaces
{
    /// <summary>
    /// Base interface for all queries
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IQuery<TEntity> : IEnumerable<TEntity>
    {
        TEntity Single();
        TEntity SingleOrDefualt();
        TEntity First();
        TEntity FirstOrDefault();
    }
}