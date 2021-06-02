using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Imp
{
    public class Person: IPerson
    {
        [ForeignKey("Accaunt")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Access Access { get; set; }

        public virtual Accaunt Accaunt { get; set; }

        public virtual ICollection<PrintedEditionOrder> BookDebt { get; set; }
        public virtual ICollection<PrintedEditionOrder> TakenBook { get; set; }

    }
}
