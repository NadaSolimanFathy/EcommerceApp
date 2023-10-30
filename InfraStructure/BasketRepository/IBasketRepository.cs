
using InfraStructure.BasketRepository.BasketEntities;

namespace InfraStructure.BasketRepository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
        Task<bool> DeleteBasketAsync(string basketId);

    }
}
