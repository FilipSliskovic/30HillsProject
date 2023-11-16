using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public double Price { get; set; }
        public string Keywords { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public string subCategory { get; set; }
        public IEnumerable<string> ImageNames { get; set; }
    }

    public class SingleProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public double Price { get; set; }
        public string Keywords { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public string subCategory { get; set; }
        public IEnumerable<string> ImageNames { get; set; }

    }

    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public ICollection<string> ImageFileNames { get; set; }
        public double Price { get; set; }
    }
}
