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
    public class EFDeleteProductCartCommand : EFUseCase, IDeleteProductCartCommand
    {
        public EFDeleteProductCartCommand(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Remove product from cart";

        public void Execute(int request)
        {
            var prodCartToRemove = Context.ProductCarts.Find(request);

            if (prodCartToRemove == null) 
            {
                throw new EntityNotFoundException("Product in cart", request);
            }

            Context.Deactivate(prodCartToRemove);
            Context.SaveChanges();

        }
    }
}
