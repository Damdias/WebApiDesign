using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.core.Entities
{
    [Table("Product")]
    public  class Product:EntityBase
    {
        public Product() { }
        public Product(Guid id)
        {
            this.Id = id;
        }
        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }
        //[StringLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
       public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
