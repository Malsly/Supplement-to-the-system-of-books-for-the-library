using BL.Imp;
using DAL.Abs;
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
        public IGenericRepository<PrintedEditionOrder> Rep { get ; set ; }
        public IMapper<PrintedEditionOrder, PrintedEditionOrderDTO> Mapper { get; set; }

        public IResult Add(PrintedEditionOrderDTO dto)
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

        public IDataResult<PrintedEditionOrderDTO> Get(int id)
        {
            return new DataResult<PrintedEditionOrderDTO>()
            {
                Data = Mapper.Map(Rep.GetByID(id)),
                ResponceStatusType = ResponceStatusType.Successed
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
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}
