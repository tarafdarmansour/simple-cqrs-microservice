﻿using ProductSearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.Domain
{
    public interface IProductSearchRepository
    {
        Task Add(SearchProduct searchProduct);
        Task<List<SearchProduct>> Find(string queryText);
    }
}
