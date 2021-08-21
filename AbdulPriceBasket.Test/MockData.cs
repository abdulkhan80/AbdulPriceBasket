using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Test
{
    public class MockData
    {
        #region "Mock Data"

        public static IList<Product> GetAllAvaliableProducts()
        {
            return new List<Product>()
            {
                new Product {Name="Soup",Price=0.65m },
                new Product {Name="Bread",Price=0.85m },
                new Product {Name="Milk",Price=1.30m },
                new Product {Name="Apples",Price=1.00m }
            };
        }

        public static IList<Offer> GetOffers()
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

            return new List<Offer>() { applesoffer, soupandbreadroffer };
        }

        #endregion
    }
}
