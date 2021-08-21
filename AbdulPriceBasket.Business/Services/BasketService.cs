using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public class BasketService : IBasketService
    {
        #region "initilization"
        private readonly IProductRepository _productrepo;
        List<Basket> _updateBasket = new List<Basket>();
        private decimal? _subTotal;
        private decimal? _total;
        #endregion

        #region "properties"

        private IList<Product> Products
        {
            get { return this._productrepo.GetAllAvaliableProducts(); }
        }
        private List<Basket> UpdateBasket
        {
            get
            {
                return _updateBasket;
            }

        }

        public decimal? CalculateSubTotal
        {
            get
            {
                if (!_subTotal.HasValue)
                    SubTotal();
                return _subTotal.Value;
            }
        }
        public decimal? CalculateTotal { get { return _total.HasValue ? _total.Value : 0; } }

        public decimal Price { get; set; }

        public int Qty { get; set; }
        #endregion

        #region "Constructor"
        public BasketService(IProductRepository productrepo)
        {
            this._productrepo = productrepo;
        }

        public BasketService()
        {

        }
        #endregion

        public IList<Basket> updateBasket(List<string> basketItems)
        {
            foreach (var item in basketItems.Distinct())
            {
                var productexistsinRepo = Products.Where(p => p.Name.Equals(item)).FirstOrDefault();
                if (productexistsinRepo == null)
                    throw new ArgumentNullException("No Product Found in Repository.  Please try again." , nameof(UpdateBasket));

                Price = Products
                    .Where(w=>w.Name.Equals(item))
                    .Select(p => p.Price).FirstOrDefault();

                Qty = basketItems
                    .Count(c=>c.Equals(item));

                UpdateBasket.Add(new Basket { ItemName = item, ItemPrice= Price, ItemQty= Qty });
            }

            return UpdateBasket;
        }

        public Bill SubTotal()
        {
            _subTotal = UpdateBasket.Sum(st => (st.ItemPrice * st.ItemQty));
            _total = _subTotal;
            return new Bill()
            {
                SubTotal = CalculateSubTotal,
                Offer = "(No offers available)",
                Total = CalculateTotal
            };
            
        }

    }//end cls...
}//end ns...
