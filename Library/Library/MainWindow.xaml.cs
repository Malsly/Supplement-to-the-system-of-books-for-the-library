using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using BL.Impl.LogicServices;
using Aspose.Pdf;
using BL.Impl;
using DAL.Imp.Mappers;
using DAL.Imp;
using Entities.Imp;
using DTObjects;
using Entities.Abs;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ReportService reportService = new ReportService();
            //Document document = reportService.CreateReport(new DateTime(), new DateTime());
            //reportService.PrintReport(document, "Report doc");

            BookService bookService = new BookService(new BookMapper(new UnitOfWork().BookRepository as GenericRepository<Book>));
            AuthorService authorService = new AuthorService(new AuthorMapper(new UnitOfWork().AuthorRepository as GenericRepository<Author>));
            PersonService personService = new PersonService(new PersonMapper(new UnitOfWork().PersonRepository as GenericRepository<Person>));

            AuthorDTO authorDTO = new AuthorDTO() { Surname = "Rowling", Name = "Joan", Birthday = DateTime.Now };
            //authorService.Add(authorDTO);

            AuthorDTO authorFromDB = authorService.GetAll().Data.Find(a => a.Name == "Joan");

            BookDTO bookDTO = new BookDTO() { Name = "Harry Potter", Rate = 5.5f, Authors = new List<AuthorDTO>() { authorFromDB } };
            PersonDTO personDTO = new PersonDTO() { Access = Access.Library, Name = "Library person", Birthday = DateTime.Now, BookDebt = new List<PrintedEditionOrderDTO>() { }, Surname = "Library person", TakenBook = new List<PrintedEditionOrderDTO>() { } };

            //bookService.Add(bookDTO);
            //personService.Add(personDTO);

            PersonDTO personFromDB = personService.GetAll().Data.FirstOrDefault(a => a.Access == Access.Library);
            BookDTO bookFromDB = bookService.GetAll().Data.FirstOrDefault(a => a.Name == "Harry Potter");

            personFromDB.TakenBook.Add(new PrintedEditionOrderDTO() { PrintedEdition = bookFromDB, StartDate = DateTime.Now, EndDate = DateTime.Now }); 

            personService.Update(personFromDB);


            List<BookDTO> books = bookService.GetAll().Data;
            List<PersonDTO> persons = personService.GetAll().Data;
            List<AuthorDTO> authors = authorService.GetAll().Data;

            //foreach (PersonDTO person in persons)
            //{
            //    personService.Delete(person);
            //}

            //foreach (BookDTO book in books)
            //{
            //    bookService.Delete(book);
            //}

            //foreach (AuthorDTO author1 in authors)
            //{
            //    authorService.Delete(author1);
            //}

            //List<BookDTO> books1 = bookService.GetAll().Data;
            //List<PersonDTO> persons1 = personService.GetAll().Data;
            //List<AuthorDTO> authors1 = authorService.GetAll().Data;

        }
    }
}
