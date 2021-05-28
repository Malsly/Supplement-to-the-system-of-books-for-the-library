using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Imp.Mappers
{

    public class PersonMapper : IMapper<Person, PersonDTO>
    {
      public GenericRepository<Person> repo;

        public PersonMapper(GenericRepository<Person> repo)
        {
            this.repo = repo;
        }

        public Person DeMap(PersonDTO dto)
        {
            Person person = repo.GetByID(dto.Id);
            if (person == null)
            {
                return EntityDTOConverter.PersonDTOtoPerson(dto);
            }
            person.Id = dto.Id;
            person.Name = dto.Name;
            person.Surname = dto.Surname;
            person.TakenBook = dto.TakenBook.Select(prorder => EntityDTOConverter.PROrderDTOtoPROrder(prorder)).ToList();
            person.MoneyDebt = dto.MoneyDebt;
            person.Access = dto.Access;
            person.Birthday = dto.Birthday;
            person.BookDebt = dto.BookDebt.Select(prorder => EntityDTOConverter.PROrderDTOtoPROrder(prorder)).ToList();

            return person;
        }

        public PersonDTO Map(Person entity)
        {
            return EntityDTOConverter.PersontoPersonDTO(entity);
        }
    }
}
