using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;
namespace DTObjects
{
    public class PersonDTO: IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public float MoneyDebt { get; set; }
        public Access Access { get; set; }
        public List<PrintedEditionOrderDTO> BookDebt { get; set; }
        public List<PrintedEditionOrderDTO> TakenBook { get; set; }
    }
}
