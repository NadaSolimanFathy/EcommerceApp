using Core.Context;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(StoreDbContext context,ILoggerFactory loggerFactory)
        
        
        {
            try
            {
                //اتأكد الاول اني عندي جدول ال براند وبعدين اتاكد انه فاضي
                if (context.ProductBrands!=null && !context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../InfraStructure/SeedData/brands.json");
                    //                                       retuen                 source   
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands != null)
                    {
                        foreach (var brand in brands)
                        {
                            await context.ProductBrands.AddAsync(brand);
                        }
                        await context.SaveChangesAsync();
                    }
              
                }

                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../InfraStructure/SeedData/types.json");
                    //                                       retuen                 source   
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if(types != null)
                    {
                        foreach (var type in types)
                        {
                            await context.ProductTypes.AddAsync(type);
                        }
                        await context.SaveChangesAsync();
                    }
                   
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../InfraStructure/SeedData/products.json");
                    //                                       retuen               source   
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            await context.Products.AddAsync(product);
                        }
                        await context.SaveChangesAsync();
                    }
                 
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}
