using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulPriceBasket.Model;

namespace AbdulPriceBasket.Business
{
    public class ProductService : IProductService
    {
        #region "initilization"
        private readonly IProductRepository _productrepo;
        #endregion

        #region "properties"
        private IList<Product> Products
        {
            get { return this._productrepo.GetAllAvaliableProducts(); }
        }
        #endregion

        #region "Constructor"
        public ProductService(IProductRepository productrepo)
        {
            this._productrepo = productrepo;
        }

        public ProductService()
        {

        }
        #endregion
        public IList<Product> avaliableProducts()
        {
            //nothing special returning all products available in product repository...
            if (Products == null)
                throw new ArgumentNullException(nameof(Products));

            return Products;
        }

    }
}
