using System;
using System.Collections.Generic;
using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Interfaces
{
    /// <summary>
    /// I query employees
    /// 
    /// This says exactly what the Notes query expect to return. Provide a very elegant API
    /// This interface has a clearly defined structure and doesn’t leak implementation details about the data store. 
    /// The implementation of INotesQuery could access a Web service, a database or files stored on disk.
    /// 
    /// /********
    /// 
    /// This interface represents our notes repository. 
    /// Only contains primary operations
    /// *********/
    /// 
    /// </summary>
    public interface INotesQuery : IQuery<Note>
    {
        INotesQuery All { get;  }
        INotesQuery ByDate(DateTime noteDate);
        INotesQuery ByTitle(string title);
        INotesQuery ByCount(int numberOfNotes);
    }

}