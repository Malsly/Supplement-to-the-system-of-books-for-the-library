using DAL.Abs;
using DTObjects;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Imp.Mappers
{

    public class PrintedEditionOrderMapper : IMapper<PrintedEditionOrder, PrintedEditionOrderDTO>
    {
        public GenericRepository<PrintedEditionOrder> repo;

        public PrintedEditionOrderMapper(GenericRepository<PrintedEditionOrder> repo)
        {
            this.repo = repo;
        }

        public PrintedEditionOrder DeMap(PrintedEditionOrderDTO dto)
        {
            PrintedEditionOrder printedEditionOrder = repo.GetByID(dto.Id);
            if (printedEditionOrder == null)
            {
                return EntityDTOConverter.PROrderDTOtoPROrder(dto);
            }
            printedEditionOrder.Id = dto.Id;
            printedEditionOrder.EndDate = dto.EndDate;
            printedEditionOrder.StartDate = dto.StartDate;
            printedEditionOrder.PrintedEdition = EntityDTOConverter.BookDTOtoBook(dto.PrintedEdition);
            return printedEditionOrder;
        }

        public PrintedEditionOrderDTO Map(PrintedEditionOrder entity)
        {
            return EntityDTOConverter.PROrdertoPROrderDTO(entity);
        }
    }
}
