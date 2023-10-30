using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.BasketRepository.BasketEntities
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public List<BasketItem> basketItems { get; set; } = new List<BasketItem>();

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set;}
    }
}
