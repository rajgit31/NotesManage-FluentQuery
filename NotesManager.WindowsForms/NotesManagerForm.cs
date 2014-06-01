using System;
using System.Windows.Forms;
using NotesManager.Business.Interfaces;
using NotesManager.WindowsForms.UI.Presenters;
using NotesManager.WindowsForms.UI.ViewModels;

namespace NotesManager.WindowsForms.UI
{
    public partial class FrmNotes : Form, INotesManagerView
    {
        private readonly NotesManagerPresenter _presenter;

        public FrmNotes(INotesService notesService)
        {
            InitializeComponent();
            _presenter = new NotesManagerPresenter(this, notesService);
            _presenter.LoadNotes();
            RegisterViewEvents();
        }

        public NoteViewModel NoteToAdd
        {
            get
            {
                return new NoteViewModel
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text
                }; 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void noteViewModel_NoteSaved(object sender, NoteSavedEventArgs e)
        {
            AddNoteToList(e.Note);
        }

        public void AddNoteToList(NoteViewModel note)
        {
            var item = new ListViewItem(note.Title);
            item.SubItems.Add(note.Description);
            lstNotes.Items.Add(item);
        }

        private void RegisterViewEvents()
        {
            _presenter.NoteSaved += noteViewModel_NoteSaved;
        }
    }
}
