using NotesManager.WindowsForms.UI.ViewModels;

namespace NotesManager.WindowsForms.UI
{
    public interface INotesManagerView
    {
        NoteViewModel NoteToAdd { get; }
    }
}