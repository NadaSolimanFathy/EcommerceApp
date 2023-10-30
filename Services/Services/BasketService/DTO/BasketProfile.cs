using AutoMapper;
using InfraStructure.BasketRepository.BasketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BasketService.DTO
{
    public class BasketProfile:Profile
    {

        public BasketProfile()
        {
            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();


        }


    }
}
