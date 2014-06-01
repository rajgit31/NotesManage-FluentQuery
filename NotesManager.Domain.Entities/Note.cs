using System;

namespace NotesManager.Domain.Entities
{
    public class Note
    {
        private DateTime _createdDate;
        public int Id { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = DateTime.Now;
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}