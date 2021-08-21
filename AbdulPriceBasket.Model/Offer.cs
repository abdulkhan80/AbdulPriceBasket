using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdulPriceBasket.Model
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public decimal Discount { get; set; }
        public int OfferApplyOnItemQty { get; set; }
        public string OfferApplyOnProduct { get; set; }
        public string OfferDiscription{ get; set; }
        public string UserMessage { get; set; }
        public bool IsOfferAvailable { get; set; }
        public DateTime OfferValidFrom { get; set; }
        public DateTime OfferValidTo { get; set; }

    }
}
