using System;
using System.Collections.Generic;
using System.Linq;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public interface IProductRepository
    {
        IList<Product> GetAllAvaliableProducts();
    }
}
