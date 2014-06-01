using System.Data.Entity.ModelConfiguration;
using NotesManager.Domain.Entities;

namespace NotesManager.Infrastructure.Data.Mappings
{
    public class NotesMap : EntityTypeConfiguration<Note>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesMap"/> class.
        /// </summary>
        public NotesMap()
        {
            this.Property(x => x.Id);
            this.Property(x => x.Title);
            this.Property(x => x.Description);
            this.Property(t => t.CreatedDate);
            this.Property(t => t.IsActive);
        }
    }
}