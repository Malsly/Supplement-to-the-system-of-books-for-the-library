using System;
using System.Collections.Generic;
using System.Text;
using Entities.Imp;
using System.Data.Entity;

namespace DAL.Abs
{
    public interface ILibraryContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Accaunt> Accaunts { get; set; }
        public DbSet<PrintedEditionOrder> PrintedEditionOrders { get; set; }

        void Dispose();
    }
}
