using BL.Abs;
using BL.Imp;
using DAL.Abs;
using DAL.Imp;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    public class AccauntService : IServise<Accaunt, AccauntDTO>, IAccauntService
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Accaunt> rep;
        public IMapper<Accaunt, AccauntDTO> Mapper { get; set; }

        public AccauntService(IMapper<Accaunt, AccauntDTO> accauntMapper) 
        {
            unitOfWork = new UnitOfWork();
            rep = unitOfWork.AccauntRepository;
            Mapper = accauntMapper;
        }

        public IGenericRepository<Accaunt> Rep
        {
            get
            {
                return rep;
            }
        }

        public IDataResult<PersonDTO> LoginAccaunt(string Login, string Password)
        {
            List<AccauntDTO> accauntDTOs = this.GetAll().Data;
            AccauntDTO accauntDTO = accauntDTOs.FirstOrDefault(accaunt => accaunt.Login == Login && accaunt.Password == Password);
            if (accauntDTO != null) 
            {
                return new DataResult<PersonDTO>()
                {
                    Data = accauntDTO.Person,
                    ResponceStatusType = ResponceStatusType.Successed
                };
            }

            return new DataResult<PersonDTO>()
            {
                Message = "Accaunt not finded",
                ResponceStatusType = ResponceStatusType.Error
            };

        }

        public IResult Add(AccauntDTO dto)
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

        public IResult Delete(AccauntDTO dto)
        {
            return this.Delete(dto.Id);
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
            unitOfWork.Save();
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}
