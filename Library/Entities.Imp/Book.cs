using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Imp
{
    public class Book: IPrintedEdition
    {
        [Key]
        public int Id { get; set; }
        public float Rate { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}
