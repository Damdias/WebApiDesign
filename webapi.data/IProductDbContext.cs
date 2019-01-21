using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Entities;

namespace webapi.data
{
   public interface IProductDbContext: IContextDbcontext<ProductDBContext>
    {
    }
}
