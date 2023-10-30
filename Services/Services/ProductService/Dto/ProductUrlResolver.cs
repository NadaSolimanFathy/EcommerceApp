using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;


namespace Services.Services.ProductService.Dto
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResultDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductUrlResolver(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
 
            
         //check that image is not null or empty
         if(!String.IsNullOrEmpty(source.PictureUrl))
            {
                var myPicUrl= $"{configuration["BaseUrl"]}{source.PictureUrl}";
                return myPicUrl;

            }


            return null;


        }//then go and handle resolver in mapping profile
    }
}
