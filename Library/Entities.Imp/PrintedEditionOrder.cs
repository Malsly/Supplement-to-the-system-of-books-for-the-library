using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Imp
{
    public class PrintedEditionOrder : IEntity
    {
        public int Id { get; set; }
        public Book PrintedEdition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
