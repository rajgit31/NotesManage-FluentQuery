using System;

namespace NotesManager.Web.UI.DomainModels
{
    public interface INotesQuery : IQuery<Note>
    {
        INotesQuery Notes();
        INotesQuery ByDate(DateTime noteDate);
        INotesQuery ByTitle(string title);
        INotesQuery Get(int numberOfNotes);
    }
}