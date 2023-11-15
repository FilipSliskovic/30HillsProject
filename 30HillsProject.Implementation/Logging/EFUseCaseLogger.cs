using _30HillsProject.Application;
using _30HillsProject.Application.Loging;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.Logging
{
    public class EFUseCaseLogger : IUseCaseLogger
    {
        private _30HillsProjectDbContext _context;

        public EFUseCaseLogger(_30HillsProjectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CreateUseCaseLog> GetLogs(UseCaseLogSearch sea)
        {
            throw new NotImplementedException();
        }

        public void Log(CreateUseCaseLog log)
        {
            var useCase = new UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Data = log.Data,
                ExcecutionDateTime = log.ExecutionTime,
                IsAuthorized = log.IsAuthorized,
                UserId = log.UserId,
                UserName = log.User

            };

            _context.UseCaseLogs.Add(useCase);

            _context.SaveChanges();
        }
    }
}
