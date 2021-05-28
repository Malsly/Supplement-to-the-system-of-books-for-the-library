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
    class AuthorService : IServise<Author, AuthorDTO>
    {
        public IGenericRepository<Author> Rep { get; set; }
        public IMapper<Author, AuthorDTO> Mapper { get; set; }

        public IResult Add(AuthorDTO dto)
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
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}
