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
    public class EFGetProductCartQuery : EFUseCase, IGetProductCartQuery
    {
        public EFGetProductCartQuery(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get products in cart";

        public PagedResponse<ProductCartDTO> Execute(ProductCartSearch search)
        {
            var query = Context.ProductCarts.Where(x => x.IsActive == true)
                .Include(x => x.Cart).Where(x => x.IsActive == true)
                .Include(x => x.Product).Where(x => x.IsActive == true)
                
                .AsQueryable();

            if (search.CartId > 0)
            {
                query = query.Where(x => x.CartId == search.CartId);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Product.Name.Contains(search.Keyword));
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

            var response = new PagedResponse<ProductCartDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ProductCartDTO
            {
                CartId = x.CartId,
                Products = x.Cart.Products.Select(y=> new CartProductDTO
                {
                    Name = y.Product.Name,
                    Quantity = y.Quantity,
                    PricePer  = y.Product.Price.Value,
                    PriceTotal = y.Quantity * y.Product.Price.Value,
                    IsActive = (bool) y.IsActive
                    

                }),
                TotalAmmount = 1,
                
                

            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();

            return response;
        }
    }
}
