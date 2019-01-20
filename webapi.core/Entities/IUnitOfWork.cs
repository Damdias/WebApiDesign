namespace webapi.core.Entities
{
    public  interface IUnitOfWork
    {
        void Commit();
        void CommitAsync();

    }
}
