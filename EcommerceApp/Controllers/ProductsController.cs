using Core.Entities;
using InfraStructure.Interfaces;
using InfraStructure.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.ProductService;
using Services.Services.ProductService.Dto;
using Services.Helper;
using EcommerceApp.HandelResponses;
using EcommerceApp.Helper;

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

        #region Normal Get
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductResultDto>>> GetProducts([FromQuery] ProductSpecification specification)
         {
            var products =  await productService.GetProductsAsync(specification);

           
            return Ok(products);

}


[HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [Cache(100)]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int? id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(product);

        }
        #endregion


        [HttpGet("Brands")]

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
            =>await productService.GetProductBrandsAsync();



        [HttpGet]
        [Route("Types")]


        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
            => await productService.GetProductTypesAsync();



     

    }
}
