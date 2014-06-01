using System;
using System.Collections.Generic;
using System.Linq;
using NotesManager.Business.Interfaces;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Interfaces;
using NotesManager.Domain.Interfaces.Data;

namespace NotesManager.Business.Services
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQueries _queries;
        private readonly IWriteRepository<Note> _notesRepository;

        public NotesService(IUnitOfWork unitOfWork, IQueries queries)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (queries == null)
            {
                throw new ArgumentNullException("queries");
            }

            _queries = queries;
            
            _unitOfWork = unitOfWork;
            _notesRepository = _unitOfWork.Repository<Note>();
        }

        public IEnumerable<Note> Notes()
        {
            return _queries.Notes.ToList();
        }

        public IEnumerable<Note> GetNotes(int numberOfNotes)
        {
            return _queries.Notes.ByCount(numberOfNotes);
        }

        public IEnumerable<Note> GetNotesWithTitleByDate(DateTime dateCreated, string title)
        {
            //fluent syntax and make the query readable like a sentence.
            return _queries.Notes.ByDate(dateCreated).ByTitle(title).ToList();
        }

        public IEnumerable<Note> GetNotes(string title)
        {
            return _queries.Notes.ByTitle(title);
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