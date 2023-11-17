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
    public class EFCreateProductCartCommand : EFUseCase, ICreateProductCartCommand
    {

        private IApplicationUser user;
        public EFCreateProductCartCommand(_30HillsProjectDbContext context, IApplicationUser user) : base(context)
        {
            this.user = user;
        }



        public int Id => 14;

        public string Name => "Add product to cart";

        public void Execute(CreateProductCartDTO request)
        {

            if(request.CartId != null)
            {
                var cart = Context.Carts.Find(request.CartId);
                if(cart == null)
                {
                    throw new EntityNotFoundException("Cart", (int)request.CartId);
                }
                var prodCart = new ProductCart
                {
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                };
                Context.ProductCarts.Add(prodCart);
                
            }

            else if (request.CartId == null)
            {
                var cart = new Cart
                {
                    UserId = user.Id,
                };

                var prodCart = new ProductCart
                {
                    Cart = cart,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                Context.ProductCarts.Add(prodCart) ;

            }

            Context.SaveChanges();

        }
    }
}
