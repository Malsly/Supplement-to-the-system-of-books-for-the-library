using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;


namespace Entities.Imp
{
    public class Person: IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Access Access { get; set; }
        public List<PrintedEditionOrder> BookDebt { get; set; }
        public List<PrintedEditionOrder> TakenBook { get; set; }
    }
}
