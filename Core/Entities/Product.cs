using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product :BaseEntity
    {

        public string Description { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set;}

        //Foreign key from  "ProductType" Table
        public int ProductTypeId { get; set; }
        // Navigational Property
        public ProductType ProductType { get; set; }
        //Foreign key from  "ProductBrand" Table
        public int ProductBrandId { get; set; }
        // Navigational Property

        public ProductBrand ProductBrand { get; set; }

    }
}
