using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application
{
    public interface IUseCaseLogger
    {
        void Log(CreateUseCaseLog log);
        IEnumerable<CreateUseCaseLog> GetLogs(UseCaseLogSearch sea);
    }
    public class UseCaseLogSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string UseCaseName { get; set; }
        public string? User { get; set; }
        public int? UserId { get; set; }

    }

    public class CreateUseCaseLog
    {
        public string? UseCaseName { get; set; }
        public string? User { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string? Data { get; set; }
        public bool IsAuthorized { get; set; }

    }
}
