using Core.Context;
using Core.Entities;
using InfraStructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly StoreDbContext _storeDbContext;
        //key-value pair data structure/ key:repository name , value :repository instance
        private Hashtable _repositories;
        public UnitOfWorkRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<int> Complete()=> await _storeDbContext.SaveChangesAsync();

        public void Dispose()=>_storeDbContext.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories is null)
                    _repositories = new Hashtable();


            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType= typeof(GenericRepository<>);
                var repositoryInstance=Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _storeDbContext);

                _repositories.Add(type, repositoryInstance);

            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
