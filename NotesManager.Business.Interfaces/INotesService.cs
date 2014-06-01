using System;
using System.Collections.Generic;
using NotesManager.Domain.Entities;

namespace NotesManager.Business.Interfaces
{
    public interface INotesService
    {
        IEnumerable<Note> Notes();
        IEnumerable<Note> GetNotes(int numberOfNotes);
        IEnumerable<Note> GetNotesWithTitleByDate(DateTime dateCreated, string title);
        IEnumerable<Note> GetNotes(string title);
        void Add(Note note);
        void Update(Note note);
    }
}