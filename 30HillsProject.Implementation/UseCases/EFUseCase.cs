using _30HillsProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases
{
    public abstract class EFUseCase
    {
        protected _30HillsProjectDbContext Context { get; }

        public EFUseCase(_30HillsProjectDbContext context)
        {
            Context = context;
        }
    }
}
