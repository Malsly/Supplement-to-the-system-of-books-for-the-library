using BL.Imp;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abs
{
    public interface IAdministratorService
    {
        IResult GivePrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person);
        IResult ReturnPrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person);
        IResult LostPrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person);
    }
}
