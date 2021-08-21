using System;
using System.Collections.Generic;
using System.Linq;
using AbdulPriceBasket.Business;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public interface IOfferService
    {
        IList<Offer> GetAllAvailableOffers();
        Bill applyOffer(IList<Basket> basket, Bill finalBillCalculate);
    }
}
