using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.Application.UseCases.DTO.Response;
using _30HillsProject.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.Queries
{
    public interface IGetProductCartQuery : IQuery<ProductCartSearch,PagedResponse<ProductCartDTO>>
    {

    }
}
