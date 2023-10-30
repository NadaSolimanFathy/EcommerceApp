using InfraStructure.BasketRepository.BasketEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BasketService.DTO
{
    public class CustomerBasketDto
    {
        [Required]

        public string Id { get; set; }
        public List<BasketItemDto> basketItems { get; set; } = new List<BasketItemDto>();

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}
