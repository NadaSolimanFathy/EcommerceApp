using Core.Context;
using Core.Entities;
using InfraStructure.Interfaces;
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
        public async Task Add(T entity)=>await context.AddAsync(entity);


        public  void Delete(T entity) =>  context.Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int? id)=> await context.Set<T>().FindAsync(id);

        public void Update(T entity)=>context.Update(entity);
    }
}
