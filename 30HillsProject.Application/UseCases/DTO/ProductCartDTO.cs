using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO
{

    


    public class ProductCartDTO
    {
        public int CartId { get; set; }
        public IEnumerable<CartProductDTO> Products { get; set; }
        public double TotalAmmount { get; set; }

    }

    public class CreateProductCartDTO
    {
        public int? CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
