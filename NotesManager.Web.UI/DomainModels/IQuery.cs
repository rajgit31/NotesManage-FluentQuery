using System.Collections.Generic;

namespace NotesManager.Web.UI.DomainModels
{
    public interface IQuery<T> : IEnumerable<T>
    {
        T Single();
        T SingleOrDefualt();
        T First();
        T FirstOrDefault();
    }
}