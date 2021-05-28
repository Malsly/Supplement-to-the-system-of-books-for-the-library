using BL.Abs;
using BL.Imp;
using DAL.Imp;
using DAL.Imp.Mappers;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl.LogicServices
{
    public class AdministratorService : IAdministratorService
    {
        PersonService personService = new PersonService(new PersonMapper(new UnitOfWork().PersonRepository as GenericRepository<Person>));
        PersonDTO libraryPerson;

        public AdministratorService() 
        {
            libraryPerson = personService.GetAll().Data.Find(personDTO => personDTO.Access == Access.Library);
        }

        public IResult GivePrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person)
        {
            PersonDTO readerPerson = personService.GetAll().Data.Find(personDTO => personDTO.Id == person.Id);
            PrintedEditionOrderDTO printedEditionOrderDTO = libraryPerson.TakenBook.FirstOrDefault(p => p.Id == printedEditionOrder.Id);

            if (printedEditionOrderDTO != null)
            {
                
                libraryPerson.TakenBook.Remove(printedEditionOrderDTO);
                readerPerson.TakenBook.Add(printedEditionOrderDTO);
                personService.Update(readerPerson);
                personService.Update(libraryPerson);

                return new Result()
                {
                    ResponceStatusType = ResponceStatusType.Successed
                };
            }

            return new Result()
            {
                Message = "Not finded book in library",
                ResponceStatusType = ResponceStatusType.Error
            };
            
        }

        public IResult LostPrintedEdition(PrintedEditionOrderDTO printedEditionOrder, PersonDTO person)
        {
            PersonDTO personLoster = personService.GetAll().Data.Find(pers => pers.Id == person.Id);
            PrintedEditionOrderDTO lostedOrder = personLoster.TakenBook.FirstOrDefault(p => p.Id == printedEditionOrder.Id);

            if (lostedOrder != null)
            {
                personLoster.TakenBook.Remove(lostedOrder);
                personLoster.BookDebt.Add(lostedOrder);
                personService.Update(personLoster);

                return new Result()
                {
                    ResponceStatusType = ResponceStatusType.Successed
                };
            }

            return new Result()
            {
                Message = "Not finded losted book in person",
                ResponceStatusType = ResponceStatusType.Error
            };
        }


        public IResult ReturnPrintedEdition(PrintedEditionOrderDTO printedEdition, PersonDTO person)
        {
            PersonDTO readerPerson = personService.GetAll().Data.Find(personDTO => personDTO.Id == person.Id);
            PrintedEditionOrderDTO returnedPrintedEditionOrderDTO = readerPerson.TakenBook.FirstOrDefault(p => p.Id == printedEdition.Id);

            if (returnedPrintedEditionOrderDTO != null)
            {

                readerPerson.TakenBook.Remove(returnedPrintedEditionOrderDTO);
                libraryPerson.TakenBook.Add(returnedPrintedEditionOrderDTO);
                personService.Update(readerPerson);
                personService.Update(libraryPerson);

                return new Result()
                {
                    ResponceStatusType = ResponceStatusType.Successed
                };
            }

            return new Result()
            {
                Message = "Not finded book in library",
                ResponceStatusType = ResponceStatusType.Error
            };
        }
    }
}
