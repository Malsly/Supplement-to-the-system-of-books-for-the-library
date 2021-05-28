﻿using BL.Imp;
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
    public class BookService : IServise<Book, BookDTO>
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Book> rep;
        public IMapper<Book, BookDTO> Mapper { get; set; }

        public BookService(IMapper<Book, BookDTO> accauntMapper)
        {
            unitOfWork = new UnitOfWork();
            rep = unitOfWork.BookRepository;
            Mapper = accauntMapper;
        }

        public IGenericRepository<Book> Rep
        {
            get
            {
                return rep;
            }
        }
        public IResult Add(BookDTO dto)
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

        public IResult Delete(BookDTO dto)
        {
            return this.Delete(dto.Id);
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
            unitOfWork.Save();
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}