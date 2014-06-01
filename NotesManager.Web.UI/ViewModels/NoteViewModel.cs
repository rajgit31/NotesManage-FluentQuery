using System;

namespace NotesManager.Web.UI.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}