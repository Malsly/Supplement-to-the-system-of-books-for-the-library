using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;

namespace DTObjects
{
    public class AccauntDTO: IEntity

    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public PersonDTO Person { get; set; }
    }
}
