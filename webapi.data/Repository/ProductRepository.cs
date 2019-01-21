using webapi.core;
using webapi.core.Entities;

namespace webapi.data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IProductDbContext productDBContext) : base(productDBContext)
        {

        }
       
    }
}
