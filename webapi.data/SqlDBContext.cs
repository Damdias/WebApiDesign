namespace webapi.data
{
    public class SqlDBContext : IProductDbContext
    {
        private readonly ProductDBContext productDBContext;

        public SqlDBContext(ProductDBContext productDBContext)
        {
            this.productDBContext = productDBContext;
        }
        public ProductDBContext DbContext => productDBContext;
        
    }
}
