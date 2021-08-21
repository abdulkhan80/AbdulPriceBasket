using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using AbdulPriceBasket.Business;

namespace AbdulPriceBasket.Client
{
    internal static class UnityConfig
    {
        internal static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IOfferRepository, OfferRepository>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IBasketService, BasketService>();
            container.RegisterType<IOfferService, OfferService>();
        }
    }
}
