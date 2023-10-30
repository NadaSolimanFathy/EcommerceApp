using InfraStructure.BasketRepository.BasketEntities;
using Services.Services.BasketService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BasketService
{
    public interface IBasketService
    {

        Task<CustomerBasketDto> GetBasketAsync(string basketId);

        Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto customerBasket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
