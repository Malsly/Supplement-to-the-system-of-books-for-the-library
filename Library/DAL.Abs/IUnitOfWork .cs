using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abs
{
    public interface IUnitOfWork
    {
        public ILibraryContext Context { get;}
        public IGenericRepository<Person> PersonRepository { get; }
        public IGenericRepository<Accaunt> AccauntRepository { get; }
        public IGenericRepository<Author> AuthorRepository { get; }
        public IGenericRepository<Book> BookRepository { get; }
        public IGenericRepository<PrintedEditionOrder> PrintedEditionOrderRepository { get; }
        void Save();
    }
}
