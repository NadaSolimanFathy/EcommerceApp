using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IUnitOfWorkRepository:IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity:BaseEntity;
        Task<int> Complete();
    }
}
