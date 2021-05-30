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
        [Key]
        public int Id { get; set; }
        public Book PrintedEdition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
