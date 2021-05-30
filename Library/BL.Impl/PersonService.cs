using BL.Imp;
using DAL.Abs;
using DAL.Imp;
using DAL.Imp.Mappers;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    public class PersonService : IServise<Person, PersonDTO>
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Person> rep;
        public IMapper<Person, PersonDTO> Mapper { get; set; }

        public PersonService()
        {
            unitOfWork = new UnitOfWork();
            rep = unitOfWork.PersonRepository;
            Mapper = new PersonMapper(new UnitOfWork().PersonRepository as GenericRepository<Person>);
        }

        public IGenericRepository<Person> Rep
        {
            get
            {
                return rep;
            }
        }

        public IResult Add(PersonDTO dto)
        {
            Rep.Insert(Mapper.DeMap(dto));
            unitOfWork.Save();
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Rep.Delete(id);
            unitOfWork.Save();
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Delete(PersonDTO dto)
        {
            return this.Delete(dto.Id);
        }

        public IDataResult<PersonDTO> Get(int id)
        {
            return new DataResult<PersonDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IDataResult<List<PersonDTO>> GetAll()
        {
            return new DataResult<List<PersonDTO>>()
            {
                Data = Rep.Get().Select(e => Mapper.Map(e)).ToList(),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Update(PersonDTO dto)
        {
            Rep.Update(Mapper.DeMap(dto));
            unitOfWork.Save();
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}