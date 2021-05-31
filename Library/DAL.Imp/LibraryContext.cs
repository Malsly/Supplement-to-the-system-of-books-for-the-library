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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accaunt>()
                .HasOptional<Person>(a => a.Person)
                .WithRequired(ab => ab.Accaunt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrintedEditionOrder>()
               .HasOptional(s => s.Book) 
               .WithRequired(ad => ad.PrintedEditionOrder);

            modelBuilder.Entity<PrintedEditionOrder>()
               .HasRequired<Person>(s => s.PersonDebtOrder)
               .WithMany(g => g.BookDebt)
               .HasForeignKey<int?>(s => s.PersonDebtOrderId);

            modelBuilder.Entity<PrintedEditionOrder>()
               .HasRequired<Person>(s => s.PersonTakenOrder)
               .WithMany(g => g.TakenBook)
               .HasForeignKey<int?>(s => s.PersonTakenOrderId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
               .HasMany<Author>(s => s.Authors)
               .WithMany(c => c.Books)
               .Map(cs =>
               {
                   cs.MapLeftKey("BookRefId");
                   cs.MapRightKey("AuthorRefId");
                   cs.ToTable("BookAuthor");
               });

        }

        public System.Data.Entity.DbSet<Person> Persons { get ; set ; }
        public System.Data.Entity.DbSet<Book> Books { get ; set ; }
        public System.Data.Entity.DbSet<Accaunt> Accaunts { get ; set ; }
        public System.Data.Entity.DbSet<PrintedEditionOrder> PrintedEditionOrders { get ; set ; }
        public System.Data.Entity.DbSet<Author> Authors { get; set; }


    }
}
