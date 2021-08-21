using System;
using System.Collections.Generic;
using System.Linq;
using AbdulPriceBasket.Business;
using AbdulPriceBasket.Model;
using System.Text;

namespace AbdulPriceBasket.Business
{
    public class OfferService : IOfferService
    {

        #region "Initilization"
        private readonly IOfferRepository _offerrepo;
        #endregion

        #region "Properties"
        private IList<Offer> Offer { get { return this._offerrepo.GetOffers(); } }

        public IList<Offer> OfferFoundInBasket { get; set; }
        #endregion

        #region "Constructor"
        public OfferService(IOfferRepository offerrepo)
        {
            this._offerrepo = offerrepo;
        }
        public OfferService()
        {

        }
        #endregion

        public IList<Offer> GetAllAvailableOffers()
        {
            //nothing special returning all offer available in offer repository...
            if (Offer==null)
                throw new ArgumentNullException(nameof(Offer));

            return Offer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basket"></param>
        /// <param name="finalBillCalculate"></param>
        /// <returns></returns>
        public Bill applyOffer(IList<Basket> basket, Bill finalBillCalculate)
        {
            Bill finalBillWithOfferCalculation = new Bill();
            StringBuilder sb = new StringBuilder();
            decimal? getSubTotal = finalBillCalculate.SubTotal;

            foreach (var item in basket)
            {
                /*
                 1- Checking here any offer found from the basket avaliable in offer repository..
                 2- If offer found of any product it also check if offer is still valid by three properties 
                    -IsOfferAvailable
                    -OfferValidFrom
                    -OfferValidTo
                    -OfferApplyOnItemQty (this property checking on how many product quantity offer will applicable.)
                */

                OfferFoundInBasket = Offer.Where(f => f.OfferName.Equals(item.ItemName) && f.IsOfferAvailable &&
                            f.OfferValidFrom <= DateTime.Now && f.OfferValidTo >= DateTime.Now
                            && f.OfferApplyOnItemQty <= item.ItemQty).ToList();

                if (OfferFoundInBasket.Count > 0 && OfferFoundInBasket != null)
                {
                    /*
                     1- Here checking of offer found on actually which product
                        -OfferApplyOnProduct
                     2- This is specifically offer of 2 soup tin and get half price off on bread
                    */
                    var getOfferItem = basket.Where(b=>b.ItemName.Equals(OfferFoundInBasket[0].OfferApplyOnProduct)).ToList();
                    if (getOfferItem.Any())
                    {
                        //Calculating discounts on one or more product if found in basket.
                        var productoffer = getOfferItem[0];
                        var calculatediscount = CalculateDiscount(productoffer);
                        finalBillCalculate.SubTotal -= calculatediscount;

                        sb.Append(string.Format("{0}{1}{2}", OfferFoundInBasket[0].UserMessage, calculatediscount, calculatediscount < 1.00m ? "p" : "£"));
                        sb.Append("\n");

                        //preparing final bill model with discounted and discounted total.  Subtotal remain same when basket setup..
                        finalBillWithOfferCalculation.SubTotal = getSubTotal;
                        finalBillWithOfferCalculation.Discount += calculatediscount;
                        finalBillWithOfferCalculation.Offer = sb.ToString();
                        finalBillWithOfferCalculation.Total = finalBillCalculate.SubTotal;
                    }
                    else
                    {
                        ////if no discount found return and set with original bill subtotal and total during basket update setup..
                        finalBillWithOfferCalculation.SubTotal = getSubTotal;
                        finalBillWithOfferCalculation.Offer = "(No offers available)";
                        finalBillWithOfferCalculation.Total = finalBillCalculate.SubTotal;

                    }
                }
                else
                {
                    if (finalBillWithOfferCalculation.Discount == 0)
                    {
                        finalBillWithOfferCalculation.SubTotal = finalBillCalculate.SubTotal;
                        finalBillWithOfferCalculation.Offer = finalBillCalculate.Offer;
                        finalBillWithOfferCalculation.Total = finalBillCalculate.Total;
                    }
                }
            }

            return finalBillWithOfferCalculation;
        }
        private decimal CalculateDiscount(Basket item)
        {
            //returning discount calculation...
            return ((item.ItemPrice * item.ItemQty) * OfferFoundInBasket[0].Discount / 100);
        }

    }//end class...
}//end ns...
