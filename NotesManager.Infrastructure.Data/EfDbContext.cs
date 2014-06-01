using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NotesManager.Domain.Entities;
using NotesManager.Infrastructure.Data.Mappings;

namespace NotesManager.Infrastructure.Data
{
    public class EfDbContext : DbContext, IDbContext
    {
        static EfDbContext()
        {
            //TODO:
            //Database.SetInitializer<EfDbContext>(new MigrateDatabaseToLatestVersion<EfDbContext, ..>(..));
        }

        public EfDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        public IDbSet<Note> Addresses { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NotesMap());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>instance of a dg entities where you can perform variouse operations. </returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>provide access to information about and control of entities that
        ///             are being tracked by the <see cref="T:System.Data.Entity.DbContext"/></returns>
        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public new Database Database { get; set; }
    }
}