using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbdulPriceBasket.Client;
using AbdulPriceBasket.Business;
using Moq;

namespace AbdulPriceBasket.Client.Test
{
    [TestClass]
    public class ClientTest
    {
        private OfferService offers;
        private BasketService bask;

        #region "Test Startup"
        [TestInitialize]
        public void SetUp()
        {
            var mockprodrepo = new Mock<IProductRepository>();
            mockprodrepo.Setup(m => m.GetAllAvaliableProducts()).Returns(MockData.GetAllAvaliableProducts());
            bask = new BasketService(mockprodrepo.Object);

            var mockofferrepo = new Mock<IOfferRepository>();
            mockofferrepo.Setup(m => m.GetOffers()).Returns(MockData.GetOffers());
            offers = new OfferService(mockofferrepo.Object);
        }

        [TestMethod]
        public void Should_Client_Display_NoDiscount_Test()
        {
            StartUp setup = new StartUp();
        }
    }
}
