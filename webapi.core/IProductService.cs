using System;
using System.Collections.Generic;
using webapi.core.Entities;

namespace webapi.core
{
    public interface IProductService
    {
        Product GetProduct(Guid id);
        void AddProduct(string name, string description, decimal price, decimal deliveryPrice);
        void UpdateProduct(string name, string description, decimal price, decimal deliveryPrice, Guid id);
        void Delete(Guid id);
        IEnumerable<Product> GetAll();
    }
}
