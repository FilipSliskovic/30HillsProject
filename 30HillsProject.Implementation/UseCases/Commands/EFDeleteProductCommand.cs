using _30HillsProject.Application.Exceptions;
using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.DataAccess;
using _30HillsProject.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Commands
{
    public class EFDeleteProductCommand : EFUseCase, IDeleteProductCommand
    {
        public EFDeleteProductCommand(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Delete a product";

        public void Execute(int request)
        {
            var prodToDelete = Context.Products.Find(request);

            if (prodToDelete == null)
            {
                throw new EntityNotFoundException("Product", request);
            }

            Context.Deactivate(prodToDelete);

            Context.SaveChanges();
        }
    }
}
