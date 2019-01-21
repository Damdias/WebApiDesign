
namespace webapi.core.Entities
{
  public  interface IContextDbcontext<T>
    {
        T DbContext { get; }
    }
    
}
