#region

using System;
using NotesManager.Business.Interfaces;
using NotesManager.WindowsForms.UI.ViewModels;

#endregion

namespace NotesManager.WindowsForms.UI.Presenters
{
    public class NotesManagerPresenter
    {
        private readonly INotesManagerView _view = null;
        private readonly INotesService _notesService;
        public event EventHandler<NoteSavedEventArgs> NoteSaved;

        public NotesManagerPresenter(INotesManagerView view, INotesService notesService)
        {
            _notesService = notesService;
            _view = view;
        }

        public void Save()
        {
            var noteToSaveViewModel = _view.NoteToAdd;
            var noteDomain = noteToSaveViewModel.ToDomain(); //Or use an automapper to do this so less coding!
            _notesService.Add(noteDomain);
            RaiseNoteSaved(noteToSaveViewModel);
        }

        private void RaiseNoteSaved(NoteViewModel noteViewModel)
        {
            if (NoteSaved != null)
            {
                NoteSaved(this, new NoteSavedEventArgs(noteViewModel));
            }
        }

        public void LoadNotes()
        {
            _notesService.GetNotes(10);
        }
    }
}
