using DAL.Abs;
using Entities.Imp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

namespace DAL.Imp
{
    public class LibraryContext : System.Data.Entity.DbContext, ILibraryContext
    {
        public LibraryContext()
        : base()
        {
        }
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(conn);
        }
        public System.Data.Entity.DbSet<Person> Persons { get ; set ; }
        public System.Data.Entity.DbSet<Book> Books { get ; set ; }
        public System.Data.Entity.DbSet<Accaunt> Accaunts { get ; set ; }
        public System.Data.Entity.DbSet<PrintedEditionOrder> PrintedEditionOrders { get ; set ; }
        public System.Data.Entity.DbSet<Author> Authors { get; set; }


    }
}
