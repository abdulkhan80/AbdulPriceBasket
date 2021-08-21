using System;
using System.Collections.Generic;
using System.Linq;
using AbdulPriceBasket.Model;


namespace AbdulPriceBasket.Business
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> GetAllAvaliableProducts()
        {
            return new List<Product>()
            {
                new Product {Id=1, Name="Soup",Price=0.65m },
                new Product {Id=2, Name="Bread",Price=0.85m },
                new Product {Id=3, Name="Milk",Price=1.30m },
                new Product {Id=4, Name="Apples",Price=1.00m },
                new Product {Id=5, Name="Lose Apple",Price=0.05m }
            };
        }
    }
}
