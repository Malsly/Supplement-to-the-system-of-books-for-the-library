using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Imp
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; set; }

    }
}
