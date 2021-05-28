using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Imp.Mappers
{
    public class AccauntMapper : IMapper<Accaunt, AccauntDTO> 
    {

        public GenericRepository<Accaunt> repo;

        public AccauntMapper(GenericRepository<Accaunt> repo)
        {
            this.repo = repo;
        }

        public Accaunt DeMap(AccauntDTO dto)
        {
            Accaunt accaunt = repo.GetByID(dto.Id);
            if (accaunt == null)
            {
                return new Accaunt()
                {
                    Id = dto.Id,
                    Login = dto.Login,
                    Password = dto.Password,
                    Person = EntityDTOConverter.PersonDTOtoPerson(dto.Person)
                };
            }
            accaunt.Id = dto.Id;
            accaunt.Login = dto.Login;
            accaunt.Password = dto.Password;
            accaunt.Person = EntityDTOConverter.PersonDTOtoPerson(dto.Person);
            return accaunt;
        }

        public AccauntDTO Map(Accaunt entity)
        {
            return new AccauntDTO()
            {
                Id = entity.Id,
                Login = entity.Login,
                Password = entity.Password,
                Person = EntityDTOConverter.PersontoPersonDTO(entity.Person),
            };
        }
    }
}
