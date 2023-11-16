using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO
{
    public class CategoryDTO
    {
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
