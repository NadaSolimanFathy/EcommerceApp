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
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext context;

        public ProductRepository(StoreDbContext _context)
        {
            context = _context;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync() => 
            await context.Set<ProductBrand>().ToListAsync();
        public async Task<Product> GetProductByIdAsync(int? id)=> 
            await context.Set<Product>().FirstOrDefaultAsync(prod=>prod.Id==id);

        public async Task<IReadOnlyList<Product>> GetProductsAsync() =>
            await context.Set<Product>().ToListAsync();

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync() => 
            await context.Set<ProductType>().ToListAsync();
        
    }
}
