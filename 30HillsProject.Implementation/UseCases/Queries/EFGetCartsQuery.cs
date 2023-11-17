using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.Application.UseCases.DTO.Response;
using _30HillsProject.Application.UseCases.DTO.Searches;
using _30HillsProject.Application.UseCases.Queries;
using _30HillsProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Queries
{
    public class EFGetCartsQuery : EFUseCase, IGetCartsQuery
    {
        public EFGetCartsQuery(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Get carts";

        public PagedResponse<CartDTO> Execute(CartSearch search)
        {
            var query = Context.Carts
                .Include(y => y.Products)
                .ThenInclude(y=>y.Product)
                .Where(y=>y.IsActive == true)
                .AsQueryable();
                

            if (search.CartId > 0)
            {
                query = query.Where(x => x.Id == search.CartId);
            }
            

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 15;
            }


            if (search.Page == null || search.Page < 1)
            {
                search.Page = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<CartDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new CartDTO
            {
                CartId = x.Id,
                Products = x.Products.Select(x => new CartProductDTO
                {
                    ProductCartId = x.Id,
                    Name = x.Product.Name,
                    PricePer = x.Product.Price.Value,
                    Quantity = x.Quantity,
                    PriceTotal = x.Quantity * x.Product.Price.Value,
                    IsActive = (bool) x.IsActive

                }),
                



            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();

            return response;
        }
    }
}
