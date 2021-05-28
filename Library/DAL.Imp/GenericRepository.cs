using DAL.Abs;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL.Imp
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ILibraryContext Context { get ; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(ILibraryContext context)
        {
            this.Context = context;
            this.DbSet = (context as LibraryContext).Set<TEntity>();
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if ((Context as LibraryContext).Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        public TEntity GetByID(int id)
        {
            TEntity entityByID = DbSet.Find(id);
            return entityByID;
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            (Context as LibraryContext).Entry(entityToUpdate).State = EntityState.Modified;
        }
         
    }
}
