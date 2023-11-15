using _30HillsProject.Application;
using _30HillsProject.Application.Loging;
using _30HillsProject.Application.UseCases;
using _30HillsProject.Application.Exceptions;
using _30HillsProject.Domain;
using Newtonsoft.Json;
using System.Diagnostics;

namespace _30HillsProject.Implementation
{
    public class UseCaseHandler
    {
        private IApplicationUser _applicationUser;
        private IExceptionLogger _exceptionLogger;
        private IUseCaseLogger _useCaseLogger;

        public UseCaseHandler(IApplicationUser applicationUser, IExceptionLogger exceptionLogger, IUseCaseLogger useCaseLogger)
        {
            _applicationUser = applicationUser;
            _exceptionLogger = exceptionLogger;
            _useCaseLogger = useCaseLogger;
        }
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                command.Execute(data);
                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _exceptionLogger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _exceptionLogger.Log(ex);
                throw;
            }
        }


        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _applicationUser.UseCaseIds.Contains(useCase.Id);

            var log = new CreateUseCaseLog
            {
                User = _applicationUser.Identity,
                ExecutionTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _applicationUser.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };

            _useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _applicationUser.Identity);
            }
        }
    }
}