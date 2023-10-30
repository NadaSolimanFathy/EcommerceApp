using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Specification
{
    public class ProductsWithTypesAndBrandsSpecification: BaseSpecifications<Product>
    {

        public ProductsWithTypesAndBrandsSpecification(ProductSpecification  specification)
            : base(prod =>
            (String.IsNullOrEmpty(specification.Search)|| prod.Name.Trim().ToLower().Contains(specification.Search))&&
            (!specification.BrandId.HasValue||prod.ProductBrandId== specification.BrandId)&&
            (!specification.TypeId.HasValue || prod.ProductTypeId == specification.TypeId)

            )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddOrderBy(p => p.Name); //sort is the default by name
            ApplyPagination(specification.PageSize*(specification.PageIndex-1), specification.PageSize);
            if (!String.IsNullOrEmpty(specification.Sort))
            {
                switch (specification.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc": 
                        AddOrderBy(p => p.Price); 
                        break;
                    default: 
                        AddOrderBy(p => p.Name); 
                        break;
                }
            }
        }



        //for GetOneElementById
        public ProductsWithTypesAndBrandsSpecification(int? id)
         : base(prod =>prod.Id   ==id )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }
    }
}
