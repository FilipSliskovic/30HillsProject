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
    public class EFDeleteCartCommand : EFUseCase, IDeleteCartCommand
    {
        public EFDeleteCartCommand(_30HillsProjectDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Checkout";

        public void Execute(int request)
        {
            var cartToDel = Context.Carts.Find(request);

            if(cartToDel == null)
            {
                throw new EntityNotFoundException("Cart", request);
            }

            Context.Deactivate(cartToDel);
            Context.SaveChanges();

        }
    }
}
