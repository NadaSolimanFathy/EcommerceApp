using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Specification
{
    public class ProductsWithFiltersForCountSpesification:BaseSpecifications<Product>
    {

       

            public ProductsWithFiltersForCountSpesification(ProductSpecification specification)
            : base(prod =>
            (String.IsNullOrEmpty(specification.Search) || prod.Name.Trim().ToLower().Contains(specification.Search)) &&
            (!specification.BrandId.HasValue || prod.ProductBrandId == specification.BrandId) &&
            (!specification.TypeId.HasValue || prod.ProductTypeId == specification.TypeId)
            )
            {

            }

    }
}
