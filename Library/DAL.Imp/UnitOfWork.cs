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

        private readonly static ILibraryContext Context = new LibraryContext();
        private readonly static GenericRepository<Accaunt> accauntRepository = new GenericRepository<Accaunt>(Context);
        private readonly static GenericRepository<Author> authorRepository = new GenericRepository<Author>(Context);
        private readonly static GenericRepository<Book> bookRepository = new GenericRepository<Book>(Context);
        private readonly static GenericRepository<Person> personRepository = new GenericRepository<Person>(Context);
        private readonly static GenericRepository<PrintedEditionOrder> PEorderRepository = new GenericRepository<PrintedEditionOrder>(Context);

        public IGenericRepository<Person> PersonRepository 
        { 
            get 
            {
                return personRepository;
            } 
        }
        public IGenericRepository<Accaunt> AccauntRepository
        {
            get
            {
                return accauntRepository;
            }
        }
        public IGenericRepository<Author> AuthorRepository
        {
            get
            {
                return authorRepository;
            }
        }
        public IGenericRepository<Book> BookRepository
        {
            get
            {
                return bookRepository;
            }
        }
        public IGenericRepository<PrintedEditionOrder> PrintedEditionOrderRepository
        {
            get
            {
                return PEorderRepository;
            }
        }

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
