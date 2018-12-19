using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStores.Models
{
    public class EFProductRespository : IProductRepository {
        private ApplicationDbContext context;
        public EFProductRespository(ApplicationDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Product> products => context.Products;
    
    }
}
