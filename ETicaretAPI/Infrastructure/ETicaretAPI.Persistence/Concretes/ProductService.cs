using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new() {Id = Guid.NewGuid() , Name = "Product1" , Stock = 10 , Price = 200 },
                new() {Id = Guid.NewGuid() , Name = "Product2" , Stock = 13 , Price = 400 },
                new() {Id = Guid.NewGuid() , Name = "Product3" , Stock = 14 , Price = 500 },
                new() {Id = Guid.NewGuid() , Name = "Product4" , Stock = 17 , Price = 600 },
                new() {Id = Guid.NewGuid() , Name = "Product5" , Stock = 12 , Price = 5500 },
                new() {Id = Guid.NewGuid() , Name = "Product6" , Stock = 18 , Price = 2300 }
            };
    }
}
