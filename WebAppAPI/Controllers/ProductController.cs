using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.core;
using webapi.core.Entities;
using webapi.data;

namespace WebAppAPI.Controllers
{
  //  [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IUnitOfWork work;
        private readonly IProductService productService;

        public ProductController(IUnitOfWork work,IProductService productService)
        {
            this.work = work;
            this.productService = productService;
        }
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            //var product = productService.GetProduct(Guid.Parse("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"));

            //var aa = new ProductDBContext();
            // productService.UpdateProduct("test1", "test des1", 101, 121, Guid.Parse("aff254fd-dd57-4c79-abcb-1c94ac88ba60"));

            //productService.Delete(Guid.Parse("aff254fd-dd57-4c79-abcb-1c94ac88ba60"));

            //work.Commit();
            //var p = aa.Products.ToList();



            //return new string[] { "value1", "value2" };

            return productService.GetAll().ToList().Select(a=> new Product(a.Id)
            {
                Name = a.Name,
                DeliveryPrice = a.DeliveryPrice,
                Price= a.Price,
                Description = a.Description
            });
        }

        // GET api/<controller>/5
        public Product Get(Guid id)
        {
            if(id == null)
            {
                return new Product();
            }
          return  productService.GetProduct(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Product productmodel)
        {
            productService.AddProduct(productmodel.Name, productmodel.Description, productmodel.Price, productmodel.DeliveryPrice);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Product productmodel)
        {
            productService.UpdateProduct(productmodel.Name, productmodel.Description, productmodel.Price, productmodel.DeliveryPrice,productmodel.Id);
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            if(id != null)
            {
                productService.Delete(id);
            }
            
        }
    }
}