using _30HillsProject.Application.Exceptions;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.Application.UseCases.Queries;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using Microsoft.EntityFrameworkCore;
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
            var prod = Context.Products.Where(x => x.Id == search && x.IsActive == true)
                .Include(x => x.Price).Where(x => x.IsActive == true)
                .Include(x => x.Category).Where(x => x.IsActive == true)
                .Include(x=>x.Images).Where(x=>x.IsActive == true)
                .FirstOrDefault();

            if(prod == null) 
            {
                throw new EntityNotFoundException("Product", search);
            }


            var response = new SingleProductDTO
            {
                Id = prod.Id,
                
                Description = prod.Description,
                Features = prod.Features,
                Keywords = prod.Keywords,
                Name = prod.Name,
                Price = prod.Price.Value,
                subCategory = prod.Category.CategoryName,
                URL = prod.Url,
                ImageNames = prod.Images.Select(x => x.Path)
            };

            if (prod.Category.ParentCategory != null)
            {
                response.Category = prod.Category.ParentCategory.CategoryName;
            }




            return response;


        }
    }
}
