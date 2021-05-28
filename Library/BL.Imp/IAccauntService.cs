using BL.Imp;
using DTObjects;
using Entities.Abs;
using Entities.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abs
{
   public interface IAccauntService
    {
        PersonDTO LoginAccaunt(string Login, string Password);
    }
}
