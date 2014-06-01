#region

using System;
using NotesManager.WindowsForms.UI.ViewModels;

#endregion

namespace NotesManager.WindowsForms.UI
{
    public class NoteSavedEventArgs : EventArgs
    {
        private readonly NoteViewModel _noteViewModel;

        public NoteSavedEventArgs(NoteViewModel noteViewModel)
        {
            _noteViewModel = noteViewModel;
        }

        public NoteViewModel Note
        {
            get { return _noteViewModel; }
        }
    }
}