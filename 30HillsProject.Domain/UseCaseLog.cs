using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Domain
{
    public class UseCaseLog
    {
        public int id { get; set; }
        public string UseCaseName { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime ExcecutionDateTime { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
