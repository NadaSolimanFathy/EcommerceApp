using Core.Context;
using Core.Entities;
using InfraStructure.Interfaces;
using InfraStructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext context;

        public GenericRepository(StoreDbContext _context)
        {
            context = _context;
        }
      

        public async Task<IReadOnlyList<T>> GetAllAsync() 
            => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int? id) 
            => await context.Set<T>().FindAsync(id);





        #region Add,Update,Delete
        public async Task Add(T entity) => await context.AddAsync(entity);


        public void Delete(T entity) => context.Remove(entity);
        public void Update(T entity) => context.Update(entity);
        #endregion


        #region Specification

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecifications<T> specs)
                      => await ApplySpecifications(specs).ToListAsync();

        public async Task<T> GetEntityWithSpecificationsAsync(ISpecifications<T> specs)
                    => await ApplySpecifications(specs).FirstOrDefaultAsync();


        private IQueryable<T> ApplySpecifications(ISpecifications<T> specs) =>
            SpecificationEvaluater<T>.GetQuery(context.Set<T>().AsQueryable(), specs);

        public async Task<int> CountAsync(ISpecifications<T> specs)
                => await ApplySpecifications(specs).CountAsync();

        #endregion

    }
}
