#region

using System;

#endregion

namespace NotesManager.WindowsForms.UI.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
