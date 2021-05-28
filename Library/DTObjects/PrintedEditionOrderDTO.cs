using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTObjects
{
    public class PrintedEditionOrderDTO : IEntity
    {
        public int Id { get; set; }
        public BookDTO PrintedEdition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
