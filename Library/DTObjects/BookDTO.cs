using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;

namespace DTObjects
{
    public class BookDTO: IPrintedEdition
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public string Name { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
