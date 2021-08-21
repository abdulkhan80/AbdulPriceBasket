using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public interface IOfferRepository
    {
        IList<Offer> GetOffers();
    }
}
