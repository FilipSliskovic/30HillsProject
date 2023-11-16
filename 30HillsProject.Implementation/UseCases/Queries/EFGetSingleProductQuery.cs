using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.Application.UseCases.Queries;
using _30HillsProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Queries
{
    public class EFGetSingleProductQuery : EFUseCase, IGetSingleProductQuery
    {
        public EFGetSingleProductQuery(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get single product";

        public SingleProductDTO Execute(int search)
        {
            var prod = Context.Products.Where(x=>x.Id == search && x.IsActive == true).FirstOrDefault();

            var response = new SingleProductDTO
            {
                Id = prod.Id,
                Category = prod.Category.ParentCategory.CategoryName,
                Description = prod.Description,
                Features = prod.Features,
                Keywords = prod.Keywords,
                Name = prod.Name,
                Price = prod.Price.Value,
                subCategory = prod.Category.CategoryName,
                URL = prod.Url,
                ImageNames = prod.Images.Select(x => x.Path)
            };


            return response;


        }
    }
}
