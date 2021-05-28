using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Linq;

namespace DAL.Imp.Mappers
{
    
    public class BookMapper : IMapper<Book, BookDTO>
    {
        public GenericRepository<Book> repo;

        public BookMapper(GenericRepository<Book> repo)
        {
            this.repo = repo;
        }

        public Book DeMap(BookDTO dto)
        {
            Book book = repo.GetByID(dto.Id);
            if (book == null)
            {
                return EntityDTOConverter.BookDTOtoBook(dto);
            }
            book.Id = dto.Id;
            book.Name = dto.Name;
            book.Rate = dto.Rate;
            book.Authors = dto.Authors.Select(author => EntityDTOConverter.AuthorDTOtoAuthor(author)).ToList();
            return book;
        }

        public BookDTO Map(Book entity)
        {
            return EntityDTOConverter.BooktoBookDTO(entity);
        }
    }
}
