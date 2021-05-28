using BL.Abs;
using BL.Imp;
using DAL.Abs;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    class AccauntService : IServise<Accaunt, AccauntDTO>, IAccauntService
    {
        public IGenericRepository<Accaunt> Rep { get; set; }
        public IMapper<Accaunt, AccauntDTO> Mapper { get; set; }

        public PersonDTO LoginAccaunt(string Login, string Password)
        {
            List<AccauntDTO> accauntDTOs = this.GetAll().Data;
            AccauntDTO accauntDTO = accauntDTOs.Find(accaunt => accaunt.Login == Login && accaunt.Password == Password);
            return accauntDTO.Person;
        }

        public IResult Add(AccauntDTO dto)
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

        public IDataResult<AccauntDTO> Get(int id)
        {
            return new DataResult<AccauntDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IDataResult<List<AccauntDTO>> GetAll()
        {
            return new DataResult<List<AccauntDTO>>()
            {
                Data = Rep.Get().Select(e => Mapper.Map(e)).ToList(),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Update(AccauntDTO dto)
        {
            Rep.Update(Mapper.DeMap(dto));
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}
