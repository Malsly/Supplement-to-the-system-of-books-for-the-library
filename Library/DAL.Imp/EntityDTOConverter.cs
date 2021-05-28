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

        private static UnitOfWork unitOfWork = new UnitOfWork();
        public static Person PersonDTOtoPerson(PersonDTO person) 
        {
            Person PersonInDB = unitOfWork.PersonRepository.GetByID(person.Id);

            if (PersonInDB != null)
            {
                return PersonInDB;
            }

            if (person.BookDebt != null && person.TakenBook != null) 
            {
                return new Person()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = person.BookDebt.Select(order => PROrderDTOtoPROrder(order)).ToList(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = person.TakenBook.Select(order => PROrderDTOtoPROrder(order)).ToList(),
                };
            }

            if (person.BookDebt != null && person.TakenBook == null)
            {
                return new Person()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = person.BookDebt.Select(order => PROrderDTOtoPROrder(order)).ToList(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = new List<PrintedEditionOrder>(),
                };
            }

            if (person.BookDebt == null && person.TakenBook != null)
            {
                return new Person()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = new List<PrintedEditionOrder>(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = person.TakenBook.Select(order => PROrderDTOtoPROrder(order)).ToList(),
                };
            }

            return new Person()
            {
                Id = person.Id,
                Access = person.Access,
                Birthday = person.Birthday,
                BookDebt = new List<PrintedEditionOrder>(),
                Name = person.Name,
                Surname = person.Surname,
                TakenBook = new List<PrintedEditionOrder>(),
            };
        }
        public static PersonDTO PersontoPersonDTO(Person person)
        {
            Person PersonInDB = unitOfWork.PersonRepository.GetByID(person.Id);

            if (PersonInDB != null)
            {
                if (PersonInDB.BookDebt != null && PersonInDB.TakenBook != null)
                {
                    return new PersonDTO()
                    {
                        Id = PersonInDB.Id,
                        Access = PersonInDB.Access,
                        Birthday = PersonInDB.Birthday,
                        BookDebt = PersonInDB.BookDebt.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                        Name = PersonInDB.Name,
                        Surname = PersonInDB.Surname,
                        TakenBook = PersonInDB.TakenBook.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                    };
                }

                if (PersonInDB.BookDebt != null && PersonInDB.TakenBook == null)
                {
                    return new PersonDTO()
                    {
                        Id = PersonInDB.Id,
                        Access = PersonInDB.Access,
                        Birthday = PersonInDB.Birthday,
                        BookDebt = PersonInDB.BookDebt.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                        Name = PersonInDB.Name,
                        Surname = PersonInDB.Surname,
                        TakenBook = new List<PrintedEditionOrderDTO>(),
                    };
                }

                if (PersonInDB.BookDebt == null && PersonInDB.TakenBook != null)
                {
                    return new PersonDTO()
                    {
                        Id = PersonInDB.Id,
                        Access = PersonInDB.Access,
                        Birthday = PersonInDB.Birthday,
                        BookDebt = new List<PrintedEditionOrderDTO>(),
                        Name = PersonInDB.Name,
                        Surname = PersonInDB.Surname,
                        TakenBook = PersonInDB.TakenBook.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                    };
                }

                return new PersonDTO()
                {
                    Id = PersonInDB.Id,
                    Access = PersonInDB.Access,
                    Birthday = PersonInDB.Birthday,
                    BookDebt = new List<PrintedEditionOrderDTO>(),
                    Name = PersonInDB.Name,
                    Surname = PersonInDB.Surname,
                    TakenBook = new List<PrintedEditionOrderDTO>(),
                };
            }


            if (person.BookDebt != null && person.TakenBook != null)
            {
                return new PersonDTO()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = person.BookDebt.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = person.TakenBook.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                };
            }

            if (person.BookDebt != null && person.TakenBook == null)
            {
                return new PersonDTO()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = person.BookDebt.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = new List<PrintedEditionOrderDTO>(),
                };
            }

            if (person.BookDebt == null && person.TakenBook != null)
            {
                return new PersonDTO()
                {
                    Id = person.Id,
                    Access = person.Access,
                    Birthday = person.Birthday,
                    BookDebt = new List<PrintedEditionOrderDTO>(),
                    Name = person.Name,
                    Surname = person.Surname,
                    TakenBook = person.TakenBook.Select(order => PROrdertoPROrderDTO(order)).ToList(),
                };
            }

            return new PersonDTO()
            {
                Id = person.Id,
                Access = person.Access,
                Birthday = person.Birthday,
                BookDebt = new List<PrintedEditionOrderDTO>(),
                Name = person.Name,
                Surname = person.Surname,
                TakenBook = new List<PrintedEditionOrderDTO>(),
            };
        }

        public static PrintedEditionOrder PROrderDTOtoPROrder(PrintedEditionOrderDTO printedEditionOrderDTO)
        {
            PrintedEditionOrder PEOrderInDB = unitOfWork.PrintedEditionOrderRepository.GetByID(printedEditionOrderDTO.Id);

            if (PEOrderInDB != null)
            {
                return PEOrderInDB;
            }

            if (printedEditionOrderDTO.PrintedEdition != null)
            {
                return new PrintedEditionOrder()
                {
                    Id = printedEditionOrderDTO.Id,
                    EndDate = printedEditionOrderDTO.EndDate,
                    PrintedEdition = BookDTOtoBook(printedEditionOrderDTO.PrintedEdition),
                    StartDate = printedEditionOrderDTO.StartDate,
                };
            }

            return new PrintedEditionOrder()
            {
                Id = printedEditionOrderDTO.Id,
                EndDate = printedEditionOrderDTO.EndDate,
                PrintedEdition = null,
                StartDate = printedEditionOrderDTO.StartDate,
            };
        }
        public static PrintedEditionOrderDTO PROrdertoPROrderDTO(PrintedEditionOrder printedEditionOrderDTO)
        {
            PrintedEditionOrder PEOrderInDB = unitOfWork.PrintedEditionOrderRepository.GetByID(printedEditionOrderDTO.Id);

            if (PEOrderInDB != null)
            {
                if (PEOrderInDB.PrintedEdition != null)
                {
                    return new PrintedEditionOrderDTO()
                    {
                        Id = PEOrderInDB.Id,
                        EndDate = PEOrderInDB.EndDate,
                        PrintedEdition = BooktoBookDTO(PEOrderInDB.PrintedEdition),
                        StartDate = PEOrderInDB.StartDate,
                    };
                }

                return new PrintedEditionOrderDTO()
                {
                    Id = PEOrderInDB.Id,
                    EndDate = PEOrderInDB.EndDate,
                    PrintedEdition = null,
                    StartDate = PEOrderInDB.StartDate,
                };
            }

            if (printedEditionOrderDTO.PrintedEdition != null)
            {
                return new PrintedEditionOrderDTO()
                {
                    Id = printedEditionOrderDTO.Id,
                    EndDate = printedEditionOrderDTO.EndDate,
                    PrintedEdition = BooktoBookDTO(printedEditionOrderDTO.PrintedEdition),
                    StartDate = printedEditionOrderDTO.StartDate,
                };
            }

            return new PrintedEditionOrderDTO()
            {
                Id = printedEditionOrderDTO.Id,
                EndDate = printedEditionOrderDTO.EndDate,
                PrintedEdition = null,
                StartDate = printedEditionOrderDTO.StartDate,
            };
        }

        public static Book BookDTOtoBook(BookDTO book)
        {
            Book bookInDB = unitOfWork.BookRepository.GetByID(book.Id);

            if (bookInDB != null) 
            {
                return bookInDB;
            }

            if (book.Authors != null)
            {
                return new Book()
                {
                    Id = book.Id,
                    Authors = book.Authors.Select(author => AuthorDTOtoAuthor(author)).ToList(),
                    Rate = book.Rate,
                    Name = book.Name,
                };
            }

            return new Book()
            {
                Id = book.Id,
                Authors = new List<Author>(),
                Rate = book.Rate,
                Name = book.Name,
            };
        }
        public static BookDTO BooktoBookDTO(Book book)
        {
            Book bookInDB = unitOfWork.BookRepository.GetByID(book.Id);

            if (bookInDB != null)
            {
                if (bookInDB.Authors != null)
                {
                    return new BookDTO()
                    {
                        Id = bookInDB.Id,
                        Authors = bookInDB.Authors.Select(author => AuthortoAuthorDTO(author)).ToList(),
                        Rate = bookInDB.Rate,
                        Name = bookInDB.Name,
                    };
                }

                return new BookDTO()
                {
                    Id = bookInDB.Id,
                    Authors = new List<AuthorDTO>(),
                    Rate = bookInDB.Rate,
                    Name = bookInDB.Name,
                };
            }

            if (book.Authors != null)
            {
                return new BookDTO()
                {
                    Id = book.Id,
                    Authors = book.Authors.Select(author => AuthortoAuthorDTO(author)).ToList(),
                    Rate = book.Rate,
                    Name = book.Name,
                };
            }

            return new BookDTO()
            {
                Id = book.Id,
                Authors = new List<AuthorDTO>(),
                Rate = book.Rate,
                Name = book.Name,
            };
        }

        public static Author AuthorDTOtoAuthor(AuthorDTO authorDTO)
        {
            Author authorInDB = unitOfWork.AuthorRepository.GetByID(authorDTO.Id);
            
            if (authorInDB != null)
            {
                return authorInDB;
            }

            return new Author()
            {
                Id = authorDTO.Id,
                Surname = authorDTO.Surname,
                Birthday = authorDTO.Birthday,
                Name = authorDTO.Name,
            };

        }
        public static AuthorDTO AuthortoAuthorDTO(Author author)
        {
            Author authorInDB = unitOfWork.AuthorRepository.GetByID(author.Id);

            if (authorInDB != null)
            {
                return new AuthorDTO()
                {
                    Id = authorInDB.Id,
                    Surname = authorInDB.Surname,
                    Birthday = authorInDB.Birthday,
                    Name = authorInDB.Name,
                };
            }

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
