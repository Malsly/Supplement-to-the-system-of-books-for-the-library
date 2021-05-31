using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Imp
{
    public class Author : IPerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public DateTime Birthday { get ; set ; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
