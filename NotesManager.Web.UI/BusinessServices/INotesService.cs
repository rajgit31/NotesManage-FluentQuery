using System;
using System.Collections.Generic;
using NotesManager.Web.UI.DomainModels;

namespace NotesManager.Web.UI.BusinessServices
{
    public interface INotesService
    {
        IEnumerable<Note> GetAllNotes();
        IEnumerable<Note> GetNotes(int numberOfNotes);
        IEnumerable<Note> GetNotesWithTitleByDate(DateTime dateCreated, string title);
        IEnumerable<Note> GetNotes(string title);
        void Add(Note note);
        void Update(Note note);
    }
}