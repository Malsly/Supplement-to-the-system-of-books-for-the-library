using BL.Abs;
using BL.Imp;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Impl.LogicServices
{
    public class AdministratorService : IAdministratorService
    {
        PersonService personService = new PersonService();

        public IResult GivePrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person)
        {
            person.TakenBook.Add(printedEditionOrder);
            personService.Update(person);
            return new Result() 
            { 
                 ResponceStatusType = ResponceStatusType.Successed
            };
        }

        public IResult LostPrintedEdition(PrintedEditionOrderDTO printedEdition, PersonDTO person)
        {
            person.TakenBook.Remove(printedEdition);
            person.BookDebt.Add(printedEdition);
            personService.Update(person);
            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }


        public IResult ReturnPrintedEdition(PrintedEditionOrderDTO printedEdition, PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
