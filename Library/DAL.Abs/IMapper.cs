using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abs
{
   public interface IMapper<TEntity, TEntityDTO> 
       where TEntity : class 
       where TEntityDTO : IEntity 
    {
        TEntityDTO Map(TEntity entity);
        TEntity DeMap(TEntityDTO dto);
    }
}
