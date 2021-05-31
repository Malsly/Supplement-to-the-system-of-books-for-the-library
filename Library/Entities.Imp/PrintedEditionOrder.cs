using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Imp
{
    public class PrintedEditionOrder : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? PersonDebtOrderId { get; set; }
        public Person PersonDebtOrder { get; set; }
        public int? PersonTakenOrderId { get; set; }
        public Person PersonTakenOrder { get; set; }


        public virtual Book Book { get; set; }
    }
}
