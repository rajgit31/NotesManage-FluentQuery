using System.Runtime.CompilerServices;

namespace NotesManager.Domain.Interfaces
{
    public interface IQueries
    {
        INotesQuery Notes { get; }
        //IEmployee Employee { get; }
    }

    public class Queries : IQueries
    {
        private INotesQuery _notes;

        public Queries(INotesQuery notes)
        {
            _notes = notes;
        }

        public INotesQuery Notes
        {
            get { return _notes; }
        }
    }

}