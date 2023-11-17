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
    public class EFGetProductsQuery : EFUseCase, IGetProductsQuery
    {
        public EFGetProductsQuery(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Get products";

        public PagedResponse<ProductDTO> Execute(ProductSearch search)
        {
            var query = Context.Products.Where(x => x.IsActive == true)
                .Include(x => x.Category).Where(x => x.IsActive == true)
                .Include(x => x.Price).Where(x => x.IsActive == true).AsQueryable();

            if (search.CategoryIds != null)
            {
                query = query.Where(x => x.CategoryId.Equals(search.CategoryIds));
            }

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword) || x.Description.Contains(search.Keyword));
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

            var response = new PagedResponse<ProductDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ProductDTO
            {
                Id = x.Id,
                Category = x.Category.ParentCategory.CategoryName,
                Description = x.Description,
                Features = x.Features,
                Keywords = x.Keywords,
                Name = x.Name,
                Price = x.Price.Value,
                subCategory = x.Category.CategoryName,
                URL = x.Url,
                ImageNames = x.Images.Select(x => x.Path)

            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();

            return response;
        }
    }
}
