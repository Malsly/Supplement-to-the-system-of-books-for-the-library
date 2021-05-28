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
    class BookService: IServise<Book, BookDTO>
    {
        public IGenericRepository<Book> Rep { get; set; }
        public IMapper<Book, BookDTO> Mapper { get; set; }

        public IResult Add(BookDTO dto)
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

        public IDataResult<BookDTO> Get(int id)
        {
            return new DataResult<BookDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IDataResult<List<BookDTO>> GetAll()
        {
            return new DataResult<List<BookDTO>>()
            {
                Data = Rep.Get().Select(e => Mapper.Map(e)).ToList(),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Update(BookDTO dto)
        {
            Rep.Update(Mapper.DeMap(dto));
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}