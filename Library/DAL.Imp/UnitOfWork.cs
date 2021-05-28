using DAL.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Imp
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;

        public UnitOfWork()
        {
            Context = new LibraryContext();
            accauntRepository = new GenericRepository<Accaunt>(Context);
            authorRepository = new GenericRepository<Author>(Context);
            bookRepository = new GenericRepository<Book>(Context);
            personRepository = new GenericRepository<Person>(Context);
            PEorderRepository = new GenericRepository<PrintedEditionOrder>(Context);
        }

        public ILibraryContext Context { get ; }

        private GenericRepository<Accaunt> accauntRepository;
        private GenericRepository<Author> authorRepository;
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Person> personRepository;
        private GenericRepository<PrintedEditionOrder> PEorderRepository;


        public IGenericRepository<Person> PersonRepository { get; }
        public IGenericRepository<Accaunt> AccauntRepository { get ; }
        public IGenericRepository<Author> AuthorRepository { get; }
        public IGenericRepository<Book> BookRepository { get; }
        public IGenericRepository<PrintedEditionOrder> PrintedEditionOrderRepository { get; }
        public void Save()
        {
            (Context as LibraryContext).SaveChanges();
        }

    public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
