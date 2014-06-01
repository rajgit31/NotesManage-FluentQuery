using System;
using System.Collections.Generic;
using System.Linq;
using NotesManager.Web.UI.DomainModels;

namespace NotesManager.Web.UI.BusinessServices
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotesQuery _notesQuery;
        private readonly IWriteRepository<Note> _notesRepository;

        public NotesService(IUnitOfWork unitOfWork, INotesQuery notesQuery)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (notesQuery == null)
            {
                throw new ArgumentNullException("notesQuery");
            }

            _notesQuery = notesQuery;
            _unitOfWork = unitOfWork;
            _notesRepository = _unitOfWork.Repository<Note>();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            INotesQuery notesQuery = _notesQuery.Notes();
            var list = notesQuery.ToList();
            return list;
        }

        public IEnumerable<Note> GetNotes(int numberOfNotes)
        {
            return _notesQuery.Notes().Get(numberOfNotes);
        }

        public IEnumerable<Note> GetNotesWithTitleByDate(DateTime dateCreated, string title)
        {
            return _notesQuery.Notes().ByDate(dateCreated).ByTitle(title);
        }

        public IEnumerable<Note> GetNotes(string title)
        {
            return _notesQuery.Notes().ByTitle(title);
        }

        public void Add(Note note)
        {
            _notesRepository.Add(note);
            _unitOfWork.Save();
        }

        public void Update(Note note)
        {
            _notesRepository.Update(note);
            _unitOfWork.Save();
        }
    }
}