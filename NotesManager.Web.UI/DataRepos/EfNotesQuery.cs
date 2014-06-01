using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NotesManager.Web.UI.DomainModels;

namespace NotesManager.Web.UI.DataRepos
{
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

      
        public IEnumerator<Note> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public INotesQuery Notes()
        {
            return this;
        }

        public INotesQuery ByDate(DateTime noteDate)
        {
            _query = _query.Where(x => x.CreatedDate == noteDate);
            return this;
        }

        public INotesQuery ByTitle(string title)
        {
            _query = _query.Where(x => x.Title == title);
            return this;
        }

        public INotesQuery Get(int numberOfNotes)
        {
            _query = _query.Take(numberOfNotes);
            return this;
        }


    }
}