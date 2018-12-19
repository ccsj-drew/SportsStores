using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStores.Models;

namespace SportsStores.Models.ViewModels
{

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
