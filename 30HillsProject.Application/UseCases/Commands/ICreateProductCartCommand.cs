using _30HillsProject.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.Commands
{
    public interface ICreateProductCartCommand : ICommand<CreateProductCartDTO>
    {
    }
}
