using AutoMapper;
using Core.Entities;
using InfraStructure.Interfaces;
using InfraStructure.Specification;
using Services.Helper;
using Services.Services.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkRepository unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWorkRepository _unitOfWork,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        => await unitOfWork.Repository<ProductBrand>().GetAllAsync();


        public async Task<ProductResultDto> GetProductByIdAsync(int? id)
        {

            var specs = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await unitOfWork.Repository<Product>().GetEntityWithSpecificationsAsync(specs);
           // if(product is null )

            var mappedProduct=mapper.Map<ProductResultDto>(product);
            return mappedProduct;

        }

        public async Task<Pagination<ProductResultDto>> GetProductsAsync(ProductSpecification specification)
        {
            var specs = new ProductsWithTypesAndBrandsSpecification(specification);
            var products = await unitOfWork.Repository<Product>().GetAllWithSpecificationsAsync(specs);
            var totalItems = await unitOfWork.Repository<Product>().CountAsync(specs);
            var mappedProducts = mapper.Map<IReadOnlyList<ProductResultDto>>(products);
            return new Pagination<ProductResultDto>(specification.PageIndex,specification.PageSize, totalItems,mappedProducts);


        }


        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
               => await unitOfWork.Repository<ProductType>().GetAllAsync();

    }
}
