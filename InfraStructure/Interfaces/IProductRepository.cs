using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Interfaces
{
    public interface IProductRepository
    {

        Task<Product> GetProductByIdAsync(int? id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
