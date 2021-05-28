using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abs;

namespace Entities.Imp
{
    public class Accaunt: IEntity

    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
    }
}
