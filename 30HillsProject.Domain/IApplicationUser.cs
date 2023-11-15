using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Domain
{
    public interface IApplicationUser
    {
        public string Identity { get; set; }
        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
        public string Username { get; set; }

    }
}
