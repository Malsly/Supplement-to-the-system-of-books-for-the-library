using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Imp
{
    public static class EntityDTOConverter
    {
        public static Person PersonDTOtoPerson(PersonDTO person) 
        {
            return new Person()
            {
                Id = person.Id,
                Access = person.Access,
                Birthday = person.Birthday,
                BookDebt = person.BookDebt.Select(order => PROrderDTOtoPROrder(order)).ToList() ,
                MoneyDebt = person.MoneyDebt,
                Name = person.Name,
                Surname = person.Surname,
                TakenBook = person.TakenBook.Select(order => PROrderDTOtoPROrder(order)).ToList(),
            };
        }
        public static PersonDTO PersontoPersonDTO(Person person)
        {
            return new PersonDTO()
            {
                Id = person.Id,
                Access = person.Access,
                Birthday = person.Birthday,
                BookDebt = person.BookDebt.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                MoneyDebt = person.MoneyDebt,
                Name = person.Name,
                Surname = person.Surname,
                TakenBook = person.TakenBook.Select(order => PROrdertoPROrderDTO(order)).ToList(),
            };
        }
        public static PrintedEditionOrder PROrderDTOtoPROrder(PrintedEditionOrderDTO printedEditionOrderDTO)
        {
            return new PrintedEditionOrder()
            {
                Id = printedEditionOrderDTO.Id,
                EndDate= printedEditionOrderDTO.EndDate,
                PrintedEdition= BookDTOtoBook(printedEditionOrderDTO.PrintedEdition),
                StartDate= printedEditionOrderDTO.StartDate,

            };
        }
        public static PrintedEditionOrderDTO PROrdertoPROrderDTO(PrintedEditionOrder printedEditionOrderDTO)
        {
            return new PrintedEditionOrderDTO()
            {
                Id = printedEditionOrderDTO.Id,
                EndDate = printedEditionOrderDTO.EndDate,
                PrintedEdition = BooktoBookDTO(printedEditionOrderDTO.PrintedEdition),
                StartDate = printedEditionOrderDTO.StartDate,

            };
        }

        public static Book BookDTOtoBook(BookDTO book)
        {
            return new Book()
            {
                Id = book.Id,
                Authors = book.Authors.Select(author => AuthorDTOtoAuthor(author)).ToList(),
                Rate = book.Rate,
                Name = book.Name,
            };
        }
        public static BookDTO BooktoBookDTO(Book book)
        {
            return new BookDTO()
            {
                Id = book.Id,
                Authors = book.Authors.Select(author => AuthortoAuthorDTO(author)).ToList(),
                Rate = book.Rate,
                Name = book.Name,
            };
        }

        public static Author AuthorDTOtoAuthor(AuthorDTO author)
        {
            return new Author()
            {
                Id = author.Id,
                Surname = author.Surname,
                Birthday = author.Birthday,
                Name = author.Name,
            };
        }
        public static AuthorDTO AuthortoAuthorDTO(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                Surname = author.Surname,
                Birthday = author.Birthday,
                Name = author.Name,
            };
        }
    }
}
