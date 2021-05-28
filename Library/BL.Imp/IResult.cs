using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Imp
{
    public interface IResult
    {
        public string Message { get; set; }
        public ResponceStatusType ResponceStatusType { get; set; }
    }
}
