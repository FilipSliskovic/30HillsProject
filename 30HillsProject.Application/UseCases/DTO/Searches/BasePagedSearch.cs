using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO.Searches
{
    public class BasePagedSearch
    {
        public int? PerPage { get; set; }
        public int? Page { get; set; }
        public string? Keyword { get; set; }
    }
}
