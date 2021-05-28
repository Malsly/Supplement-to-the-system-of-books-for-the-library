using BL.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Impl
{
    class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }
    }
}