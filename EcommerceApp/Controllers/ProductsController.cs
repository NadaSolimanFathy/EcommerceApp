using Core.Entities;
using InfraStructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
namespace EcommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>>GetProducts()
            =>await productService.GetProductsAsync();



        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int? id)
         => await productService.GetProductByIdAsync(id);



        [HttpGet("Brands")]

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
            =>await productService.GetProductBrandsAsync();



        [HttpGet]
        [Route("Types")]


        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
            => await productService.GetProductTypesAsync();



     

    }
}
