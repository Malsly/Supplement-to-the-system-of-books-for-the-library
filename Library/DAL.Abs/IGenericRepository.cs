﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Entities.Abs;


namespace DAL.Abs
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public ILibraryContext Context { get; set; }
        IEnumerable<TEntity> Get();
        TEntity GetByID(int? id);
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Delete(int? id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

    }
}
