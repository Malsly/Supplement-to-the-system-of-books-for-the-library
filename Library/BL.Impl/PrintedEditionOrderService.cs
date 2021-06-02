using BL.Imp;
using DAL.Abs;
using DAL.Imp;
using DAL.Imp.Mappers;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Impl
{
    public class PrintedEditionOrderService : IServise<PrintedEditionOrder, PrintedEditionOrderDTO>
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<PrintedEditionOrder> rep;
        public IMapper<PrintedEditionOrder, PrintedEditionOrderDTO> Mapper { get; set; }

        public PrintedEditionOrderService()
        {
            unitOfWork = new UnitOfWork();
            rep = unitOfWork.PrintedEditionOrderRepository;
            Mapper = new PrintedEditionOrderMapper(new UnitOfWork().PrintedEditionOrderRepository as GenericRepository<PrintedEditionOrder>);
        }

        public IGenericRepository<PrintedEditionOrder> Rep
        {
            get
            {
                return rep;
            }
        }

        public IResult Add(PrintedEditionOrderDTO dto)
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

        public IResult Delete(PrintedEditionOrderDTO dto)
        {
            return this.Delete(dto.Id);
        }

        public IDataResult<PrintedEditionOrderDTO> Get(int id)
        {
            return new DataResult<PrintedEditionOrderDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IDataResult<PrintedEditionOrderDTO> Get(int? id)
        {
            if (id != null) 
            {
                return new DataResult<PrintedEditionOrderDTO>()
                {
                    Data = Mapper.Map(Rep.GetByID(id)),
                    ResponceStatusType = ResponceStatusType.Successed
                };
            }
            return new DataResult<PrintedEditionOrderDTO>()
            {
                ResponceStatusType = ResponceStatusType.Error
            };
        }

        public IDataResult<List<PrintedEditionOrderDTO>> GetAll()
        {
            return new DataResult<List<PrintedEditionOrderDTO>>()
            {
                Data = Rep.Get().Select(e => Mapper.Map(e)).ToList(),
                ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult Update(PrintedEditionOrderDTO dto)
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
