using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.Exceptions
{
    public class ForbiddenUseCaseExecutionException : Exception
    {
        public ForbiddenUseCaseExecutionException(string useCase, string user) : base($"User {user} tried to execute {useCase} without having permission")
        {

        }
    }
}
