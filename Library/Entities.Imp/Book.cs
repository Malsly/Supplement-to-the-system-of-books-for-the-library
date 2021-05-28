using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;

namespace Entities.Imp
{
    public class Book: IPrintedEdition
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}
