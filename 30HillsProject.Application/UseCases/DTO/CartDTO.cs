using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public IEnumerable<CartProductDTO> Products { get; set; }
    }

    public class CartProductDTO
    {
        public int ProductCartId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public double PricePer { get; set; }
        public double PriceTotal { get; set; }
    }
}
