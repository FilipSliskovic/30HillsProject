using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Domain
{
    public class User : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();
    }
}
