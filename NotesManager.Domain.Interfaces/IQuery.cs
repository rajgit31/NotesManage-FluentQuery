using System.Collections.Generic;

namespace NotesManager.Domain.Interfaces
{
    public interface IQuery<T> : IEnumerable<T>
    {
        T Single();
        T SingleOrDefualt();
        T First();
        T FirstOrDefault();
    }
}