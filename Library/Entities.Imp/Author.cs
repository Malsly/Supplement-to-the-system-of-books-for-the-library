using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Imp
{
    public class Author : IPerson
    {
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public DateTime Birthday { get ; set ; }
        public int Id { get ; set ; }
    }
}
