using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTObjects
{
    public class AuthorDTO : IPerson
    {
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public DateTime Birthday { get ; set ; }
        public int Id { get ; set ; }
    }
}
