using System;
using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Interfaces
{
    public interface INotesQuery : IQuery<Note>
    {
        INotesQuery Notes();
        INotesQuery ByDate(DateTime noteDate);
        INotesQuery ByTitle(string title);
        INotesQuery Get(int numberOfNotes);
    }
}