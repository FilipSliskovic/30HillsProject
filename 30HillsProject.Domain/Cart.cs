using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProductCart> Products { get; set; }
    }
}
