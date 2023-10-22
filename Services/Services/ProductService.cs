using Core.Entities;
using InfraStructure.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkRepository unitOfWork;

        public ProductService(IUnitOfWorkRepository _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        => await unitOfWork.Repository<ProductBrand>().GetAllAsync();
        

        public async Task<Product> GetProductByIdAsync(int? id)=>
            await unitOfWork.Repository<Product>().GetByIdAsync(id);
       
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
           => await unitOfWork.Repository<Product>().GetAllAsync();


        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
               => await unitOfWork.Repository<ProductType>().GetAllAsync();

    }
}
