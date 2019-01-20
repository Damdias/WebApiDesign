using System;
using System.Collections.Generic;
using webapi.core;
using webapi.core.Entities;
using System.Linq;

namespace webapi.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(string name, string description, decimal price, decimal deliveryPrice)
        {
            var product = new Product(Guid.NewGuid())
            {
                DeliveryPrice = deliveryPrice,
                Price = price,
                Description = description,
                Name = name
            };
            productRepository.Add(product);
        }

        public void Delete(Guid id)
        {
            productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.List().ToList();
        }

        public Product GetProduct(Guid id)
        {
            return productRepository.GetById(id);
        }

        public void UpdateProduct(string name, string description, decimal price, decimal deliveryPrice, Guid id)
        {
            var product = new Product(id)
            {
                DeliveryPrice = deliveryPrice,
                Price = price,
                Description = description,
                Name = name
            };
            productRepository.Edit(product);
        }
    }
}
