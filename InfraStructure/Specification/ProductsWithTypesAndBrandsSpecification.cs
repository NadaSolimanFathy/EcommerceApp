using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Specification
{
    internal class ProductsWithTypesAndBrandsSpecification: BaseSpecifications<Product>
    {

        public ProductsWithTypesAndBrandsSpecification(ProductSpecification  specification)
            : base(prod =>
            (!specification.BrandId.HasValue||prod.ProductBrandId== specification.BrandId)&&
            (!specification.TypeId.HasValue || prod.ProductTypeId == specification.TypeId)

            )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);



        }



        //for GetOneElementById
        public ProductsWithTypesAndBrandsSpecification(int id)
         : base(prod =>prod.Id   ==id )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }
    }
}
