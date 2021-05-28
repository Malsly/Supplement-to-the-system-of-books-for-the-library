using DAL.Abs;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Imp
{
    public interface IServise<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        public IGenericRepository<TEntity> Rep { get; set; }
        IDataResult<List<TEntityDTO>> GetAll();
        IDataResult<TEntityDTO> Get(int id);
        IResult Add(TEntityDTO dto);
        IResult Update(TEntityDTO dto);
        IResult Delete(int id);

    }
}
