using webapi.core.Entities;
namespace webapi.data.Repository
{
    public class ProductUnitOfwork : IUnitOfWork
    {
        private readonly ProductDBContext dbContext;

        public ProductUnitOfwork(ProductDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async void CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
