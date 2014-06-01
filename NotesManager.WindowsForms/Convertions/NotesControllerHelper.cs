#region

using System.Collections.Generic;
using System.Linq;
using NotesManager.Domain.Entities;
using NotesManager.WindowsForms.UI.ViewModels;

#endregion

namespace NotesManager.WindowsForms.UI
{
    public static class NotesControllerHelper
    {
        public static IEnumerable<NoteViewModel> ConvertToViewModel(this IEnumerable<Note> notes)
        {
            var notesList = notes.Select(note => new NoteViewModel()
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                CreatedDate = note.CreatedDate

            }).ToList();

            return notesList;
        }

        public static Note ToDomain(this NoteViewModel noteViewModel)
        {
            return new Note()
            {
                Id = noteViewModel.Id,
                Title = noteViewModel.Title,
                Description = noteViewModel.Description,
                CreatedDate = noteViewModel.CreatedDate
            };
        }
    }
}