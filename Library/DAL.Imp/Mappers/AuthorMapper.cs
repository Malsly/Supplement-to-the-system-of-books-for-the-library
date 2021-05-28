using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Imp.Mappers
{
  
    class AuthorMapper : IMapper<Author, AuthorDTO>
    {
        public GenericRepository<Author> repo;

        public AuthorMapper(GenericRepository<Author> repo)
        {
            this.repo = repo;
        }

        public Author DeMap(AuthorDTO dto)
        {
            Author author = repo.GetByID(dto.Id);
            if (author == null)
            {
                return EntityDTOConverter.AuthorDTOtoAuthor(dto);
            }
            author.Id = dto.Id;
            author.Name = dto.Name;
            author.Birthday = dto.Birthday;
            author.Surname = dto.Surname;
            return author;
        }

        public AuthorDTO Map(Author entity)
        {
            return EntityDTOConverter.AuthortoAuthorDTO(entity);
        }
    }
}
