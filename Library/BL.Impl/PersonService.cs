using BL.Imp;
using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    class PersonService : IServise<Person, PersonDTO>
    {
        public IGenericRepository<Person> Rep { get; set; }
        public IMapper<Person, PersonDTO> Mapper { get; set; }

        public IResult Add(PersonDTO dto)
        {
            Rep.Insert(Mapper.DeMap(dto));
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Rep.Delete(id);
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
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
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}