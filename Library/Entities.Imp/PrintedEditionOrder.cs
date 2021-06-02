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

        public int? BookDebtId { get; set; }
        public virtual Person BookDebt { get; set; }
        public int? TakenBookId { get; set; }
        public virtual Person TakenBook { get; set; }


        public virtual Book Book { get; set; }
    }
}
