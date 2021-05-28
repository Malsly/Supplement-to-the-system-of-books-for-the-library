using BL.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Impl
{
    class Result : IResult
    {
        public string Message { get ; set ; }
        public ResponceStatusType ResponceStatusType { get; set; }
    }
}
