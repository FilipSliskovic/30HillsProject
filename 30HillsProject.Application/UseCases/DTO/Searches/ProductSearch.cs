﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Application.UseCases.DTO.Searches
{
    public class ProductSearch : BasePagedSearch
    {
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
