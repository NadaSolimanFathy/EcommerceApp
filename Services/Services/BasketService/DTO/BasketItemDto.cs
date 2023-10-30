using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.BasketService.DTO
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string ProductName { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage ="price can't be less than 0.1")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Quantity { get; set; }
        [Required]

        public string PictureUrl { get; set; }

        [Required]
        public string Brand { get; set; }
        [Required]

        public string Type { get; set; }
    }
}
