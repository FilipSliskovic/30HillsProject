using _30HillsProject.Application.Exceptions;
using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Commands
{
    public class EFCreateProductCommand : EFUseCase, ICreateProductCommand
    {
        public EFCreateProductCommand(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Create product";

        public void Execute(CreateProductDTO request)
        {
            if(request.Price <=  0)
            {
                throw new UseCaseConflictException("Price can't be below 0");
            }
            var price = new Price
            {
                Value = request.Price,
            };
            var prod = new Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Features = request.Features,
                Keywords = request.Keywords,
                Price = price,
                Url = request.Url,
                


            };

            if (request.ImageFileNames != null)
            {
                foreach (var imageName in request.ImageFileNames)
                {
                    var i = new Image
                    {
                        Path = imageName,
                    };
                    prod.Images.Add(i);
                }
            }

            Context.Products.Add(prod);
            Context.SaveChanges();
        }
    }
}
