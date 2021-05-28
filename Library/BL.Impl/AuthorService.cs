using BL.Imp;
using DAL.Abs;
using DAL.Imp;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    public class AuthorService : IServise<Author, AuthorDTO>
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Author> rep;
        public IMapper<Author, AuthorDTO> Mapper { get; set; }

        public AuthorService(IMapper<Author, AuthorDTO> accauntMapper)
        {
            unitOfWork = new UnitOfWork();
            rep = unitOfWork.AuthorRepository;
            Mapper = accauntMapper;
        }

        public IGenericRepository<Author> Rep
        {
            get
            {
                return rep;
            }
        }

        public IResult Add(AuthorDTO dto)
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

        public IResult Delete(AuthorDTO dto)
        {
            return this.Delete(dto.Id);
        }

        public IDataResult<AuthorDTO> Get(int id)
        {
            return new DataResult<AuthorDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IDataResult<List<AuthorDTO>> GetAll()
        {
            return new DataResult<List<AuthorDTO>>()
            {
                Data = Rep.Get().Select(e => Mapper.Map(e)).ToList(),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Update(AuthorDTO dto)
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
