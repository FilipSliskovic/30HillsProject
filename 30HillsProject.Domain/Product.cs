using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Domain
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Features { get; set; }
        public string? Keywords { get; set; }
        public string? Url { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }
        public int PriceId { get; set; }


        public ICollection<Image> Images { get; set; } = new List<Image>();
        public Price? Price { get; set; }
        public Category? Category { get; set; }
    }
}
