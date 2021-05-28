using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abs
{
    public interface ILibraryWorker: IPerson
    {
        public Access Access { get; set; }
    }
}
