using System;
using System.Collections.Generic;
using System.Linq;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public class OfferRepository : IOfferRepository
    {
        private IList<Offer> _offer;
        public IList<Offer> GetOffers()
        {
            Offer applesoffer = new Offer();
            applesoffer.OfferId = 1;
            applesoffer.OfferName = "Apples";
            applesoffer.OfferApplyOnProduct = "Apples";
            applesoffer.OfferApplyOnItemQty = 1;
            applesoffer.Discount = 10m;
            applesoffer.IsOfferAvailable = true;
            applesoffer.OfferDiscription = "10% discount on apples";
            applesoffer.UserMessage = string.Format("{0} {1}% off: -", applesoffer.OfferApplyOnProduct, applesoffer.Discount.ToString());
            applesoffer.OfferValidFrom = DateTime.UtcNow;
            applesoffer.OfferValidTo = DateTime.UtcNow.AddDays(7);

            Offer soupandbreadroffer = new Offer();
            soupandbreadroffer.OfferId = 2;
            soupandbreadroffer.OfferName = "Soup";
            soupandbreadroffer.OfferApplyOnProduct = "Bread";
            soupandbreadroffer.OfferApplyOnItemQty = 2;
            soupandbreadroffer.Discount = 50m;
            soupandbreadroffer.IsOfferAvailable = true;
            soupandbreadroffer.OfferDiscription = "Buy 2 tins of soup and get a loaf of bread for half price";
            soupandbreadroffer.UserMessage = string.Format("{0} {1}% off: -", soupandbreadroffer.OfferName, soupandbreadroffer.Discount.ToString());
            soupandbreadroffer.OfferValidFrom = DateTime.UtcNow;
            soupandbreadroffer.OfferValidTo = DateTime.UtcNow.AddDays(7);

            _offer = new List<Offer>() { applesoffer, soupandbreadroffer };

            return _offer;
        }

    }
}
