using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Imp
{
    public class Book : IPrintedEdition
    {   
        public int Id { get; set; }
        public float Rate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        
        [Key, ForeignKey("PrintedEditionOrder")]
        public int? PrintedEditionOrderID { get; set; }
        public virtual PrintedEditionOrder PrintedEditionOrder { get; set; }
    }
}
