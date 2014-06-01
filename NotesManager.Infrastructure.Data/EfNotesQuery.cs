using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Interfaces;

namespace NotesManager.Infrastructure.Data
{

    /// <summary>
    /// The implementation of INotesQuery could access a Web service, a database or files stored on disk.
    /// </summary>
    public class EfNotesQuery : INotesQuery
    {
        public IQueryable<Note> _query;

        public EfNotesQuery(IDbContext context)
        {
            _query = context.Set<Note>();
        }

        public Note Single()
        {
            return _query.Single();
        }

        public Note SingleOrDefualt()
        {
            return _query.SingleOrDefault();
        }

        public Note First()
        {
            return _query.SingleOrDefault();
        }

        public Note FirstOrDefault()
        {
            return _query.FirstOrDefault();
        }

        public INotesQuery All
        {
            get { return this; }
        }

        public INotesQuery ByDate(DateTime noteDate)
        {
            _query = _query.Where(x => x.CreatedDate == noteDate);
            return this;
        }

        public INotesQuery ByTitle(string title)
        {
            _query = _query.Where(x => x.Title.Contains(title));
            return this;
        }

        public INotesQuery ByCount(int numberOfNotes)
        {
            _query = _query.Take(numberOfNotes);
            return this;
        }

        public IEnumerator<Note> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    // //Tradition approach
    //public interface IRepostory<T>
    //{
    //    //Primary operations
    //    IEnumerable<Note> GetNotes();
    //    IEnumerable<Note> GetNotesByTitle(string title);
    //    IEnumerable<Note> GetNotesByDate(DateTime noteDate);
    //    IEnumerable<Note> GetNumberOfNotes(int numberOfNotes);

    //    //Secondary operations
    //    IEnumerable<Note> GetActiveNotesByTitle(DateTime noteDate, string title);
    //}

    //public class Repostory : IRepostory<Note>
    //{
    //    private IDbContext _dbContext;
    //    private IDbSet<Note> _notes;

    //    public Repostory(IDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //        _notes = _dbContext.Set<Note>();
    //    }

    //    public IEnumerable<Note> GetNotes()
    //    {
    //        return _notes;
    //    }

    //    public IEnumerable<Note> GetNotesByTitle(string title)
    //    {
    //        return _notes.Where(x => x.Title.Contains(title));
    //    }

    //    public IEnumerable<Note> GetNotesByDate(DateTime noteDate)
    //    {
    //        return _notes.Where(x => x.CreatedDate == noteDate);
    //    }

    //    public IEnumerable<Note> GetNumberOfNotes(int numberOfNotes)
    //    {
    //        return _notes.Take(numberOfNotes);
    //    }

    //    public IEnumerable<Note> GetActiveNotesByTitle(DateTime noteDate, string title)
    //    {
    //        return _notes.Where(x => x.IsActive && x.Title.Contains(title));
    //    }
    //}
}