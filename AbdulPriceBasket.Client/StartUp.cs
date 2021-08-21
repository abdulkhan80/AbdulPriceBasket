using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulPriceBasket.Business;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Client
{

    public class StartUp
    {

        #region "Initilization"
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IOfferService _offerService;
        #endregion

        #region "Program Startup and Initial Configuration"


        public StartUp(IProductService productService,
            IBasketService basketService,
            IOfferService offerService)
        {
            // Unity has created this instance and resolved all dependencies.
            this._productService = productService;
            this._basketService = basketService;
            this._offerService = offerService;
        }

        public void Run(List<string> userinput)
        {

            if (userinput == null || userinput.Count < 1)
            {
                throw new ArgumentNullException(nameof(userinput));
            }

            var products = this._productService.avaliableProducts();

            if (products != null)
            {
                var updatebasket = this._basketService.updateBasket(userinput);
                var offers = this._offerService.GetAllAvailableOffers();

                if (offers == null)
                    throw new ArgumentNullException(nameof(products));

                var result = this._offerService.applyOffer(updatebasket, this._basketService.SubTotal());

                    Console.WriteLine($"Subtotal: {result.SubTotal:c2}");
                    Console.WriteLine(result.Offer);
                    Console.WriteLine($"Total: {result.Total:c2}");
            }
            else
            {
                throw new ArgumentNullException(nameof(products));
            }


        }
        #endregion


        #region "Client-side validation"
        //private static int Validation(string loanrequest)
        //{
        //    int loanamountRequest;

        //    if (!int.TryParse(loanrequest, out loanamountRequest))
        //    {
        //        throw new ArgumentException("Invalid value for loan amount parameter.", nameof(loanamountRequest));
        //    }

        //    if (loanamountRequest < borrowerminloanRequest || loanamountRequest > borrowermaxloanRequest)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(loanamountRequest), loanamountRequest, $"Loan amount must be inside the interval of {borrowerminloanRequest} to {borrowermaxloanRequest}.");
        //    }

        //    if (loanamountRequest % borrowerloanStep != 0)
        //    {
        //        throw new ArgumentException($"Loan amount must be dividable by {borrowerloanStep}.", nameof(loanamountRequest));
        //    }

        //    return loanamountRequest;
        //}


        #endregion
    }
}
